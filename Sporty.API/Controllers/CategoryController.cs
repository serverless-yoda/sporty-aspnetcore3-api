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
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork uow;


        public CategoryController(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        [HttpGet()]
        public IActionResult GetCategories()
        {
            var fromDb = uow.Category.GetAll();
            return Ok(fromDb);
        }

        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var fromDb = uow.Category.Get(id);
            return Ok(fromDb);
        }

        [HttpPost()]
        public IActionResult PostCategory([FromBody] Category category)
        {
            uow.Category.Add(category);
            uow.Save();

            return CreatedAtAction(nameof(GetCategory), new { id = category.Id,  }, category);
            //return Ok(category);
        }

        [HttpPut("{id}")]
        public IActionResult PutCategory([FromRoute]int id, [FromBody] Category Category)
        {
            if (id != Category.Id)
            {
                return BadRequest();
            }

            try
            {
                uow.Category.Update(Category);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (uow.Category.Get(id) == null)
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<Category> DeleteCategory([FromRoute] int id)
        {
            var Category = uow.Category.Get(id);
            if (Category == null) return NotFound();

            uow.Category.Remove(Category);
            uow.Save();

            return Category;
        }
    }

}