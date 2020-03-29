using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sporty.API.Classes.Parameters;
using Sporty.Domain.Entities;
using Sporty.Domain.IUnitOfWork;
using Sporty.Infrastructure.Data;
using Sporty.Infrastructure.Data.Extensions;

namespace Sporty.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("v{v:apiVersion}/products")]
    //[Route("products")] -- this is for using HttpHeader versioning
    [ApiController]
    [Authorize]
    public class ProductV1Controller : ControllerBase
    {
        private readonly SportyContext context;

        public ProductV1Controller(SportyContext context)
        {
            this.context = context;
            this.context.Database.EnsureCreated();

        }
        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery] ProductFilterParameters query) {

            IQueryable<Product> products = this.context.Products;

            if(query.MaxPrice != null && query.MinPrice != null)
            {
                products = products.Where(p => p.Price >= query.MinPrice && p.Price <= query.MaxPrice);
            }

            if(!string.IsNullOrEmpty(query.Sku))
            {
                products = products.Where(p => p.Sku.Equals(query.Sku));
            }

            if (!string.IsNullOrEmpty(query.Name))
            {
                products = products.Where(p => p.Name.ToLower().Contains(query.Name.ToLower()));
            }

            if(!string.IsNullOrEmpty(query.SortBy))
            {
                if(typeof(Product).GetProperty(query.SortBy) != null)
                {
                    products = products.OrderByCustom(query.SortBy,query.SortOrder);
                }
            }

            products = products.Skip(query.Size * (query.Page - 1))
                        .Take(query.Size);

            return Ok(await products.ToArrayAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await this.context.Products.FindAsync(id);
            if(product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct([FromBody] Product product) 
        { 
           
                this.context.Products.Add(product);
                await this.context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetProduct),
                new { id = product.Id },
                product);
           
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> PutProduct([FromRoute] int id, [FromBody] Product product) {
            if (id != product.Id)
            {
                return BadRequest();
            }
            this.context.Entry(product).State = EntityState.Modified;

            try
            {
                await this.context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                if(this.context.Products.Find(id) == null)
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id) {
            var product = await this.context.Products.FindAsync(id);
            if (product == null) return NotFound();

            this.context.Products.Remove(product);
            await this.context.SaveChangesAsync();

            return product;
        }
    }

    [ApiVersion("2.0")]
    [Route("v{v:apiVersion}/products")]
    [ApiController]
    public class ProductV2Controller: ControllerBase
    {
        public ProductV2Controller(IUnitOfWork uow)
        {

        }
    }
}