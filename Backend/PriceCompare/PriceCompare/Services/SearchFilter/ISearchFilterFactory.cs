using PriceCompare.Constants.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceCompare.Services.SearchFilter
{
    public interface ISearchFilterFactory
    {
        ISearchFilterService GetSearhFilterService(WebSiteNames webSiteName);
    }
}
