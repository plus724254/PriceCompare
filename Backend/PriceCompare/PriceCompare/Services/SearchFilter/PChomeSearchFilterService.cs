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
        private readonly IPriceFilterFactory _priceFilterFactory;
        public PChomeSearchFilterService(IPriceFilterFactory priceFilterFactory)
        {
            _priceFilterFactory = priceFilterFactory;
        }

        public string GetFilterUrl(SearchFilterModel searchFilter)
        {
            var searchUrl = _searchPrefixUrl;
            searchUrl += searchFilter.Keyword;
            searchUrl += _priceFilterFactory.GetPriceFilterService(WebSiteNames.PChome).GetPriceFilter(new PriceFilterDTO
            {
                MinPrice = searchFilter.MinPrice,
                MaxPrice = searchFilter.MaxPrice,
            });

            return searchUrl;
        }
    }
}
