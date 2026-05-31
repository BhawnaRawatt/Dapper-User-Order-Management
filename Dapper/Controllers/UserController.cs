using Dapper.Models;
using Dapper.Services;
using Microsoft.AspNetCore.Mvc;

namespace Dapper.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController:ControllerBase
    {
        private readonly DbServices _db;

        public UserController(DbServices db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_db.GetUsers());
        }

        [HttpPost("add")]
        public IActionResult Add(User user)
        {
            _db.AddUsers(user);
            return Ok("User Added");
        }

    }
}
