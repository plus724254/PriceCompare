using PriceCompare.Models;
using PriceCompare.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceCompare.Services
{
    public interface IWebScratchService
    {
        public Task<List<WebDataDTO>> GetWebDataDetailByFilter(SearchFilterModel searchFilter);
    }
}
