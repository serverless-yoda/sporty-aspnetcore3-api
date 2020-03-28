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
    public class OrderRepository : Repository<Order>, IOrderRepository
    {

        private readonly SportyContext db;

        public OrderRepository(SportyContext db) : base(db)
        {
            this.db = db;
        }
        
        public void Update(Order order)
        {
            var fromdb = db.PRoducts.FirstOrDefault(c => c.Id == order.Id);
            if (fromdb != null)
            {
                fromdb.OrderDate = order.OrderDate;
                fromdb.UserId = order.UserId; 
            }
        }
    }
}
