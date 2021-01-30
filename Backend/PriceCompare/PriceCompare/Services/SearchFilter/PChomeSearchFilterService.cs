using PriceCompare.Constants.Enums;
using PriceCompare.Models;
using PriceCompare.Models.DTO.Filter;
using PriceCompare.Services.SearchFilter.PriceFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceCompare.Services.SearchFilter
{
    public class PChomeSearchFilterService : ISearchFilterService
    {
        private const string _searchPrefixUrl = "https://ecshweb.pchome.com.tw/search/v3.3/all/results?page=1&sort=sale/dc&q=";

        public string GetFilterUrl(IPriceFilterService priceFilterService, SearchFilterModel searchFilter)
        {
            var searchUrl = _searchPrefixUrl;
            searchUrl += searchFilter.Keyword;
            searchUrl += priceFilterService.GetPriceFilter(new PriceFilterDTO
            {
                MinPrice = searchFilter.MinPrice,
                MaxPrice = searchFilter.MaxPrice,
            });

            return searchUrl;
        }
    }
}
