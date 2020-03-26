using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sporty.API.Classes.Parameters
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

        public string SortBy { get; set; } = "Id";

        private string _sortOrder = "asc";
        public string SortOrder { 
            get {
                return _sortOrder;
            }
 
            set {
                if(value.ToLower().Equals("asc") || value.ToLower().Equals("desc"))
                {
                    _sortOrder = value;
                }
            } 
        
        }
    }
}
