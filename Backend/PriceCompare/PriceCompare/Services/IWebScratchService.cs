using PriceCompare.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceCompare.Services
{
    public interface IWebScratchService
    {
        public Task<string> GetWebData(string url);
        public Task<List<WebDataDTO>> GetWebDataDetailByKeyword(string searchKeyword);
    }
}
