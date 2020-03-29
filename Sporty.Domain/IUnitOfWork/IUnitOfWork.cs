using Sporty.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sporty.Domain.IUnitOfWork
{
    public interface IUnitOfWork: IDisposable
    {
        ICategoryRepository Category { get; }
        IOrderRepository Order { get; }
        IProductRepository Product { get; }
        IUserRepository User { get; }

        void Save();

    }
}
