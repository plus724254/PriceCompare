using PriceCompare.Models.DTO.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceCompare.Services.SearchFilter.PriceFilter
{
    public class PChomePriceFilterService : IPriceFilterService
    {
        private const string _searchPrefixUrl = "http://m.momoshop.com.tw/search.momo?couponSeq=&cpName=&searchType=1&cateLevel=-1&cateCode=-1&ent=k&_imgSH=fourCardStyle&searchKeyword=";
        public string GetPriceFilter(PriceFilterDTO priceFilterDTO)
        {
            if(priceFilterDTO.MinPrice == null && priceFilterDTO.MaxPrice == null)
            {
                return string.Empty;
            }
            else
            {
                return $"price{priceFilterDTO.MinPrice}-{priceFilterDTO.MaxPrice}";
            }
        }
    }
}
