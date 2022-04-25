using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericLayer
{
    public class SortingData
    {
        private const int maxPageSize = 50;

        public int PageNumber { get; set; } = 1;
        
        private int _pageSize = 10;
        
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                if (value < 1)
                {
                    _pageSize = 1;
                }
                else if (value > maxPageSize)
                {
                    _pageSize = maxPageSize;
                }
                else
                {
                    _pageSize = value;
                }
            }
        }

        public string OrderBy { get; set; }
    }
}
