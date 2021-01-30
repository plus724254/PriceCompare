using PriceCompare.Models;
using PriceCompare.Services.SearchFilter.PriceFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceCompare.Services.SearchFilter
{
    public interface ISearchFilterService
    {
        string GetFilterUrl(IPriceFilterService priceFilterService, SearchFilterModel searchFilter);
    }
}
