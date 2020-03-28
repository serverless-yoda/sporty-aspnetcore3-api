using Sporty.Domain.Entities;
using Sporty.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sporty.Domain.Interfaces
{
    public interface IOrderRepository: IRepository<Order>
    {
        void Update(Order order);
    }
}
