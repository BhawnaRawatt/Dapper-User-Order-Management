using Dapper.Models;
using Dapper.Services;
using Microsoft.AspNetCore.Mvc;

namespace Dapper.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController: ControllerBase
    {
        private readonly DbServices _db;

        public OrderController(DbServices db)
        {
            _db = db;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_db.GetOrders());
        }

        [HttpPost("add")]
        public ActionResult Add(Order order)
        {
            _db.AddOrder(order);
            return Ok("Order Added");
        }

    }
}
