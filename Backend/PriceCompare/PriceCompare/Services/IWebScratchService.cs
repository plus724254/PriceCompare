using PriceCompare.Constants.WebSiteParameters;
using PriceCompare.Models;
using PriceCompare.Models.DTO;
using System.Threading.Tasks;

namespace PriceCompare.Services
{
    public interface IWebScratchService
    {
        public Task<WebDataDTO> GetWebDataDetailByFilter(SearchFilterModel searchFilter, WebSiteParameterAbstract webSiteParameter);
    }
}
