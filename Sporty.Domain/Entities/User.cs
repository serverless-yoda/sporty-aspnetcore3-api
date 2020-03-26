using System;
using System.Collections.Generic;
using System.Text;

namespace Sporty.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public virtual List<Order> Orders { get; set; }
    }
}
