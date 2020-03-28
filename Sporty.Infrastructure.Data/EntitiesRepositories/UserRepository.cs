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
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly SportyContext db;

        public UserRepository(SportyContext db): base(db)
        {
            this.db = db;
        }
        public void Update(User user)
        {
            var fromdb = db.Users.FirstOrDefault(c => c.Id == user.Id);
            if (fromdb != null)
            {
                fromdb.Email = user.Email;
            }
        }
    }
}
