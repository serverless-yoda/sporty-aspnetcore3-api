using Sporty.Domain.Entities;
using Sporty.Domain.Interfaces;
using Sporty.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sporty.Domain.EntitiesRepositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public void Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
