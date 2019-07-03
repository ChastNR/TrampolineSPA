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
    public class BlogController : ControllerBase
    {
        private readonly IRepository _repo;

        public BlogController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IEnumerable<Blog> Get() => _repo.GetAll<Blog>();
    }
}