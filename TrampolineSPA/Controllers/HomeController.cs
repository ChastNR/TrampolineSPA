using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrampolineSPA.Extensions.EmailSender;
using TrampolineSPA.Models;
using TrampolineSPA.Models.Entity;

namespace TrampolineSPA.Controllers
{
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        private readonly ApplicationContext _db;
        private readonly IEmailSender _emailSender;

        public HomeController(ApplicationContext context, IEmailSender emailSender)
        {
            _db = context;
            _emailSender = emailSender;
        }

        [Route("GetBlogList")]
        [HttpGet]
        public IEnumerable<Blog> GetBlogList() => _db.Blogs.ToList();

        [Route("GetServiceList")]
        [HttpGet]
        public IEnumerable<Service> GetServiceList() => _db.Services.ToList();

        [Route("GetServiceForm")]
        [HttpGet]
        public JsonResult GetServiceForm(int? id)
        {
            var service = _db.Services.Find(id);

            return Json(service);
        }

        [Route("SendServiceForm")]
        [HttpPost]
        public async Task<IActionResult> SendServiceForm(Client client, int serviceId)
        {
            if (!ModelState.IsValid) return new ObjectResult(client);
            
            await CreateClient(client, serviceId);

            _emailSender.SendInstructions(_db.Services.Find(serviceId).Name, client.Email, "Bla-bla");
            return Json("Your information has been submitted!");
        }

        [Route("GetClientInfo")]
        [HttpGet]
        public JsonResult GetClientInfo(string email)
        {
            var client = _db.Clients.FirstOrDefault(c => c.Email == email);

            return Json(client);
        }
        
        [Route("SendRecord")]
        [HttpPost]
        public async Task SendRecord(Record record)
        {
            if (ModelState.IsValid)
            {
                _db.Records.Add(record);
                await _db.SaveChangesAsync();
            }
        }
        
        public async Task CreateClient(Client client, int serviceId)
        {
            var clientExist =
                _db.Clients.FirstOrDefault(c => c.Email == client.Email | c.PhoneNumber == client.PhoneNumber);

            if (clientExist != null)
            {
                ClientServices clientServices = new ClientServices
                {
                    ClientId = clientExist.Id,
                    ServiceId = serviceId
                };

                _db.ClientServices.Add(clientServices);
                await _db.SaveChangesAsync();
            }
            else
            {
                _db.Clients.Add(client);

                ClientServices clientServices = new ClientServices
                {
                    ClientId = client.Id,
                    ServiceId = serviceId
                };

                _db.ClientServices.Add(clientServices);
                await _db.SaveChangesAsync();
            }
        }
    }
}