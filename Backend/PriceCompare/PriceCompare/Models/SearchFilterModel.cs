using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceCompare.Models
{
    public class SearchFilterModel
    {
        public string Keyword { get; set; }
        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }
        public bool IsHardSearch { get; set; }
    }
}
