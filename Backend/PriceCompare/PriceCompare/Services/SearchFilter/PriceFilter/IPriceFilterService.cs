using PriceCompare.Models.DTO.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceCompare.Services.SearchFilter.PriceFilter
{
    public interface IPriceFilterService
    {
        string GetPriceFilter(PriceFilterDTO priceFilterDTO);
    }
}
