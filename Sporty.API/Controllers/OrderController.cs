using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sporty.Domain.Entities;
using Sporty.Domain.IUnitOfWork;

namespace Sporty.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IUnitOfWork uow;


        public OrderController(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        [HttpGet()]
        public IActionResult GetOrders()
        {
            var fromDb = uow.Order.GetAll();
            return Ok(fromDb);
        }

        [HttpGet("{id}")]
        public IActionResult GetOrder(int id)
        {
            var fromDb = uow.Order.Get(id);
            return Ok(fromDb);
        }

        [HttpPost()]
        public IActionResult PostOrder([FromBody] Order order)
        {
            uow.Order.Add(order);
            uow.Save();

            return CreatedAtAction(nameof(GetOrder), new { id = order.Id, }, order);
            //return Ok(Order);
        }

        [HttpPut("{id}")]
        public IActionResult PutOrder([FromRoute]int id, [FromBody] Order order)
        {
            if (id != order.Id)
            {
                return BadRequest();
            }

            try
            {
                uow.Order.Update(order);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (uow.Order.Get(id) == null)
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<Order> DeleteOrder([FromRoute] int id)
        {
            var order = uow.Order.Get(id);
            if (order == null) return NotFound();

            uow.Order.Remove(order);
            uow.Save();

            return order;
        }
    }

}