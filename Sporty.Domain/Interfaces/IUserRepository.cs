using Sporty.Domain.Entities;
using Sporty.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sporty.Domain.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        void Update(User user);
    }
}
