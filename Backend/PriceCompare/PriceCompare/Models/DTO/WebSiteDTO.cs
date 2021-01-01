using PriceCompare.Constants.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceCompare.Models.DTO
{
    public class WebSiteDTO
    {
        public WebSiteNames Name { get; set; }
        public WebSiteDataTypes DataType { get; set; }
        public string SearchPrefixUrl { get; set; }
        public string MinPriceText { get; set; }
        public string MaxPriceText { get; set; }
    }
}
