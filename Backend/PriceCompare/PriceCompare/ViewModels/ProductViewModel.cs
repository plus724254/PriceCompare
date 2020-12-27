using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceCompare.ViewModels
{
    public class ProductViewModel
    {
        public string ImageUrl { get; set; }
        public string PageUrl { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }
        public string Price { get; set; }
    }
}
