using Sporty.Domain.Entities;
using Sporty.Domain.Interfaces;
using Sporty.Domain.IRepository;
using Sporty.Infrastructure.Data;
using Sporty.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sporty.Domain.EntitiesRepositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        

        private readonly SportyContext db;

        public ProductRepository(SportyContext db) : base(db)
        {
            this.db = db;
        }

        public void Update(Product product)
        {
            var fromdb = db.Products.FirstOrDefault(c => c.Id == product.Id);
            if (fromdb != null)
            {
                fromdb.Description = product.Description;
                fromdb.IsAvailable = product.IsAvailable;
                fromdb.Name = product.Name;
                fromdb.Sku = product.Sku;
                fromdb.CategoryId = product.CategoryId;
            }
        }
    }
}
