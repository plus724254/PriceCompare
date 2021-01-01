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
    public class MoMoSearchFilterService : ISearchFilterService
    {
        private const string _searchPrefixUrl = "http://m.momoshop.com.tw/search.momo?couponSeq=&cpName=&searchType=1&cateLevel=-1&cateCode=-1&ent=k&_imgSH=fourCardStyle&searchKeyword=";
        private const string _minPriceText = "_advPriceS";
        private const string _maxPriceText = "_advPriceE";

        private readonly IPriceFilterFactory _priceFilterFactory;
        public MoMoSearchFilterService(IPriceFilterFactory priceFilterFactory)
        {
            _priceFilterFactory = priceFilterFactory;
        }

        public string GetFilterUrl(SearchFilterModel searchFilter)
        {
            var searchUrl = _searchPrefixUrl;
            searchUrl += searchFilter.Keyword;
            searchUrl += _priceFilterFactory.GetPriceFilterService(WebSiteNames.MoMo).GetPriceFilter(new PriceFilterDTO
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
