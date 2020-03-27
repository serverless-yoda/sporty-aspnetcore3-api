using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace Sporty.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }

        [Required]
        public int UserId { get; set; }

        [JsonIgnore]
        public virtual User User  { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
