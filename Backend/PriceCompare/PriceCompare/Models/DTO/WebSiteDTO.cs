﻿using PriceCompare.Constants.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceCompare.Models.DTO
{
    public class WebSiteDTO
    {
        public string Name { get; set; }
        public WebSiteDataTypes DataType { get; set; }
        public string SearchPrefixUrl { get; set; }
    }
}
