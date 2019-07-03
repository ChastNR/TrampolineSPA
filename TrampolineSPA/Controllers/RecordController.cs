using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Interface;
using Repository.Models;

namespace TrampolineSPA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordController : ControllerBase
    {
        private readonly IRepository _repo;

        public RecordController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public async Task Post(Record record)
        {
            if (ModelState.IsValid)
            {
                _repo.Create(record);
                await _repo.SaveAsync();
            }
        }
    }
}