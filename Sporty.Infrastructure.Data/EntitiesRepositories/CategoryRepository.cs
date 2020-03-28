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
    public class CategoryRepository :  Repository<Category>, ICategoryRepository
    {
        private readonly SportyContext db;

        public CategoryRepository(SportyContext db): base(db)
        {
            this.db = db;
        }
        public void Update(Category category)
        {
            var fromdb = db.Categories.FirstOrDefault(c => c.Id == category.Id);
            if(fromdb != null)
            {
                fromdb.Name = category.Name;
            }
        }
    }
}
