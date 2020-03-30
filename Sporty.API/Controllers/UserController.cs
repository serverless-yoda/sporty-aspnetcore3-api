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
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork uow;


        public UserController(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        [HttpGet()]
        public IActionResult GetUsers()
        {
            var fromDb = uow.User.GetAll();
            return Ok(fromDb);
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var fromDb = uow.User.Get(id);
            return Ok(fromDb);
        }

        [HttpPost()]
        public IActionResult PostUser([FromBody] User user)
        {
            uow.User.Add(user);
            uow.Save();

            return CreatedAtAction(nameof(GetUser), new { id = user.Id, }, user);
            //return Ok(User);
        }

        [HttpPut("{id}")]
        public IActionResult PutUser([FromRoute]int id, [FromBody] User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            try
            {
                uow.User.Update(user);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (uow.User.Get(id) == null)
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<User> DeleteUser([FromRoute] int id)
        {
            var user = uow.User.Get(id);
            if (user == null) return NotFound();

            uow.User.Remove(user);
            uow.Save();

            return user;
        }
    }

}