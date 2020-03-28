using Sporty.Domain.Entities;
using Sporty.Domain.Interfaces;
using Sporty.Domain.IRepository;
using Sporty.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sporty.Domain.EntitiesRepositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public void Update(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
