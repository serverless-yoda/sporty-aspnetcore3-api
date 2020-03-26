using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IActionResult> GetProducts() {
            return Ok(await this.context.Products.ToArrayAsync());
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