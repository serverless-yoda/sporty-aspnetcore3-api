using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sporty.API.Classes.QueryParameters
{
    public class QueryParameters
    {
        private int _size = 30;
        const int _maxSize = 100;

        public int Page { get; set; }
        public int Size
        {
            get
            {
                return _size;
            }

            set
            {
                _size = Math.Min(_maxSize, value);
            }
        }
    }
}
