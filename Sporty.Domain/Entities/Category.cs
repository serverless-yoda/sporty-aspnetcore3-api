using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sporty.Domain.Entities
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
