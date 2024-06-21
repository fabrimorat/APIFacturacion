using APIFacturacion.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace APIFacturacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private static List<Order> _orders = new List<Order>();

        [HttpPost]
        public ActionResult<Order> CreateOrder([FromBody] Order order)
        {
            _orders.Add(order);
            return CreatedAtAction(nameof(GetOrder), new { id = _orders.Count - 1 }, order);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Order>> GetAllOrders()
        {
            return _orders;
        }

        [HttpGet("{id}")]
        public ActionResult<Order> GetOrder(int id)
        {
            if (id < 0 || id >= _orders.Count)
            {
                return NotFound();
            }
            return _orders[id];
        }
    }
}
