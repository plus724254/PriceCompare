using PriceCompare.Constants.WebSiteParameters;
using PriceCompare.Models;
using PriceCompare.Models.DTO;
using PriceCompare.Services.Scratch;
using System.Threading.Tasks;

namespace PriceCompare.Services
{
    public class WebScratchService : IWebScratchService
    {
        public async Task<WebDataDTO> GetWebDataDetailByFilter(SearchFilterModel searchFilter, WebSiteParameterAbstract webSiteParameter)
        {
            if(!searchFilter.IsHardSearch)
            {
                webSiteParameter.PageScratchService = new StaticPageScratchService();
            }

            return new WebDataDTO()
            {
                WebSiteName = webSiteParameter.WebSiteName,
                Data = await webSiteParameter.PageScratchService.GetWebData(GetWebUrl(webSiteParameter, searchFilter)),
            };
        }

        private string GetWebUrl(WebSiteParameterAbstract webSiteParameter, SearchFilterModel searchFilter)
        {
            return webSiteParameter.SearchFilterService.GetFilterUrl(webSiteParameter.PriceFilterService, searchFilter);
        }
    }
}
