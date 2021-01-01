using PriceCompare.Constants.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceCompare.Services.SearchFilter.PriceFilter
{
    public interface IPriceFilterFactory
    {
        IPriceFilterService GetPriceFilterService(WebSiteNames webSiteName);
    }
}
