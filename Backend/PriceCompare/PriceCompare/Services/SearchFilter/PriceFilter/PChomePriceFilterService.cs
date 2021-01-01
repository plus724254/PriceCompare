using PriceCompare.Models.DTO.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceCompare.Services.SearchFilter.PriceFilter
{
    public class PChomePriceFilterService : IPriceFilterService
    {
        public string GetPriceFilter(PriceFilterDTO priceFilterDTO)
        {
            if(priceFilterDTO.MinPrice == null && priceFilterDTO.MaxPrice == null)
            {
                return string.Empty;
            }
            else
            {
                return $"&price={priceFilterDTO.MinPrice ?? 0}-{priceFilterDTO.MaxPrice ?? int.MaxValue}";
            }
        }
    }
}
