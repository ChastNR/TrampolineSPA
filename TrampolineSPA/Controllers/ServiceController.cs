using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Repository.Interface;
using Repository.Models;
using TrampolineSPA.Extensions.SmsSender;
using TrampolineSPA.Extensions.EmailSender;

namespace TrampolineSPA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : Controller
    {
        private readonly IEmailSender _emailSender;
        private readonly ISmsSender _smsSender;
        private readonly IRepository _repo;

        public ServiceController(IRepository repo, IEmailSender emailSender, ISmsSender smsSender)
        {
            _repo = repo;
            _smsSender = smsSender;
            _emailSender = emailSender;
        }

        [HttpGet]
        public IEnumerable<Service> Get() => _repo.GetAll<Service>();

        [HttpGet("{id}")]
        public JsonResult Get(int id) => Json(_repo.GetById<Service>(id));

        [HttpPost]
        public async Task<IActionResult> Post(Client client, int serviceId)
        {
            if (!ModelState.IsValid) return new ObjectResult(client);

            await CreateClient(client, serviceId);

            string service = _repo.GetById<Service>(serviceId).Name;

            _emailSender.SendInstructions(service, client.Email, "Bla-bla");
            _smsSender.SendSmsInstructions(service, client.PhoneNumber, "Bla-bla");
            return Json("Your information has been submitted!");
        }

        [NonAction]
        public async Task CreateClient(Client client, int serviceId)
        {
            var clientExist =
                _repo.GetFirst<Client>(c => c.Email == client.Email | c.PhoneNumber == client.PhoneNumber);

            if (clientExist != null)
            {
                _repo.Create(new ClientServices
                {
                    ClientId = clientExist.Id,
                    ServiceId = serviceId
                });
                await _repo.SaveAsync();
            }
            else
            {
                _repo.Create(client);
                _repo.Create(new ClientServices
                {
                    ClientId = client.Id,
                    ServiceId = serviceId
                });
                await _repo.SaveAsync();
            }
        }
    }
}