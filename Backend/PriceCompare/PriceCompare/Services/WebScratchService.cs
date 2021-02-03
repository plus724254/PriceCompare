using PriceCompare.Common;
using PriceCompare.Common.Factory;
using PriceCompare.Constants.Enums;
using PriceCompare.Constants.WebSiteParameters;
using PriceCompare.Models;
using PriceCompare.Models.DTO;
using PriceCompare.Services.Scratch;
using System.Threading.Tasks;

namespace PriceCompare.Services
{
    public class WebScratchService : IWebScratchService
    {
        public async Task<WebDataDTO> GetWebDataDetailByFilter(SearchFilterModel searchFilter, WebSiteSetupDTO webSiteSetup)
        {
            return new WebDataDTO()
            {
                WebSiteName = webSiteSetup.WebSiteName,
                Data = searchFilter.IsHardSearch?
                    await webSiteSetup.PageScratchService.GetWebData(GetWebUrl(webSiteSetup, searchFilter))
                    : await PageScratchServiceFactory.CreateInstance(WebSitePageTypes.StaticPage).GetWebData(GetWebUrl(webSiteSetup, searchFilter))
            };
        }

        private string GetWebUrl(WebSiteSetupDTO webSiteSetup, SearchFilterModel searchFilter)
        {
            return webSiteSetup.SearchFilterService.GetFilterUrl(webSiteSetup.PriceFilterService, searchFilter);
        }
    }
}
