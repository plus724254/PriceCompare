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
    public class YahooSearchFilterService : ISearchFilterService
    {
        private const string _searchPrefixUrl = "https://tw.buy.yahoo.com/search/product?p=";
        private const string _minPriceText = "minp";
        private const string _maxPriceText = "maxp";

        public string GetFilterUrl(IPriceFilterService priceFilterService, SearchFilterModel searchFilter)
        {
            var searchUrl = _searchPrefixUrl;
            searchUrl += searchFilter.Keyword;
            searchUrl += priceFilterService.GetPriceFilter(new PriceFilterDTO
            {
                MinPriceWord = _minPriceText,
                MaxPriceWord = _maxPriceText,
                MinPrice = searchFilter.MinPrice,
                MaxPrice = searchFilter.MaxPrice,
            });

            return searchUrl;
        }
    }
}
