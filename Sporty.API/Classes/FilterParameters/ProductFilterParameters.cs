using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sporty.API.Classes;

namespace Sporty.API.Classes.Parameters
{
    public class ProductFilterParameters : QueryParameters
    {
        public string Sku { get; set; }
        public decimal? MinPrice { get; set; }

        public decimal? MaxPrice { get; set; }

        public string Name { get; set; }
    }
}
