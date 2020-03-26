using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sporty.API.Classes.Parameters;
using Sporty.Domain.Entities;
using Sporty.Infrastructure.Data;

namespace Sporty.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly SportyContext context;

        public ProductController(SportyContext context)
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
    }
}