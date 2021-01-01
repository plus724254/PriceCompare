using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceCompare.Models.DTO.Filter
{
    public class PriceFilterDTO
    {
        public string MinPriceWord { get; set; }
        public string MaxPriceWord { get; set; }
        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }
    }
}
