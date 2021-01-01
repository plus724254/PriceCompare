using PriceCompare.Models.DTO.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceCompare.Services.SearchFilter.PriceFilter
{
    public class CommomPriceFilterService : IPriceFilterService
    {
        public string GetPriceFilter(PriceFilterDTO priceFilterDTO)
        {
            var priceFilter = string.Empty;

            if(priceFilterDTO.MinPrice != null)
            {
                priceFilter += $"&{priceFilterDTO.MinPriceWord}={priceFilterDTO.MinPrice}";
            }

            if (priceFilterDTO.MaxPrice != null)
            {
                priceFilter += $"&{priceFilterDTO.MaxPriceWord}={priceFilterDTO.MaxPrice}";
            }

            return priceFilter;
        }
    }
}
