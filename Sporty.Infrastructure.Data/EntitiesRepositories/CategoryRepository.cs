using Sporty.Domain.Entities;
using Sporty.Domain.Interfaces;
using Sporty.Domain.IRepository;
using Sporty.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sporty.Domain.EntitiesRepositories
{
    public class CategoryRepository :  Repository<Category>, ICategoryRepository
    {
        public void Update(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
