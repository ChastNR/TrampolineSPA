using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Repository.Interface;
using Repository.Models;
using TrampolineSPA.Extensions.EmailSender;

namespace TrampolineSPA.Controllers
{
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        private readonly IEmailSender _emailSender;
        private readonly IRepository _repo;
        
        public HomeController(IRepository repo, IEmailSender emailSender)
        {
            _repo = repo;
            _emailSender = emailSender;
        }

        [Route("GetBlogList")]
        [HttpGet]
        public IEnumerable<Blog> GetBlogList() => _repo.GetAll<Blog>();

        [Route("GetServiceList")]
        [HttpGet]
        public IEnumerable<Service> GetServiceList() => _repo.GetAll<Service>();

        [Route("GetServiceForm")]
        [HttpGet]
        public JsonResult GetServiceForm(int? id) => Json(_repo.GetById<Service>(id));

        [Route("SendServiceForm")]
        [HttpPost]
        public async Task<IActionResult> SendServiceForm(Client client, int serviceId)
        {
            if (!ModelState.IsValid) return new ObjectResult(client);
            
            await CreateClient(client, serviceId);

            _emailSender.SendInstructions(_repo.GetById<Service>(serviceId).Name, client.Email, "Bla-bla");
            return Json("Your information has been submitted!");
        }

        [Route("GetClientInfo")]
        [HttpGet]
        public JsonResult GetClientInfo(string email) => Json(_repo.GetFirst<Client>(c => c.Email == email));

        [Route("SendRecord")]
        [HttpPost]
        public async Task SendRecord(Record record)
        {
            if (ModelState.IsValid)
            {
                _repo.Create(record);
                await _repo.SaveAsync();
            }
        }
        
        public async Task CreateClient(Client client, int serviceId)
        {
            var clientExist =
                _repo.GetFirst<Client>(c => c.Email == client.Email | c.PhoneNumber == client.PhoneNumber);

            if (clientExist != null)
            {
                ClientServices clientServices = new ClientServices
                {
                    ClientId = clientExist.Id,
                    ServiceId = serviceId
                };

                _repo.Create(clientServices);
                await _repo.SaveAsync();
            }
            else
            {
                _repo.Create(client);

                ClientServices clientServices = new ClientServices
                {
                    ClientId = client.Id,
                    ServiceId = serviceId
                };

                _repo.Create(clientServices);
                await _repo.SaveAsync();
            }
        }
    }
}