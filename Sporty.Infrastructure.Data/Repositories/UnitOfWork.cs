using Sporty.Domain.EntitiesRepositories;
using Sporty.Domain.Interfaces;
using Sporty.Domain.IUnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sporty.Infrastructure.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SportyContext db;

        public UnitOfWork(SportyContext db)
        {
            this.db = db;
            Category = new CategoryRepository(db);
            Product = new ProductRepository(db);
            Order = new OrderRepository(db);
            User = new UserRepository(db);
        }
        public ICategoryRepository Category  { get; private set;}

        public IOrderRepository Order { get; private set; }

        public IProductRepository Product { get; private set; }

        public IUserRepository User { get; private set; }

        public void Dispose()
        {
            this.db.Dispose();
        }

        public void Save()
        {
            this.db.SaveChanges();
        }
    }
}
