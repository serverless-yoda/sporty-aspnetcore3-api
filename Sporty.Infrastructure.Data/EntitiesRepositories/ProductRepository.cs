using Sporty.Domain.Entities;
using Sporty.Domain.Interfaces;
using Sporty.Domain.IRepository;
using Sporty.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sporty.Domain.EntitiesRepositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public void Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
