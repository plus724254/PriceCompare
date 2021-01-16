using PriceCompare.Constants;
using PriceCompare.Constants.Enums;
using PriceCompare.Models;
using PriceCompare.Models.DTO;
using PriceCompare.Services.Scratch;
using PriceCompare.Services.SearchFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PriceCompare.Services
{
    public class WebScratchService : IWebScratchService
    {
        private readonly IPageScratchFactory _pageScratchFactory;
        private readonly ISearchFilterFactory _searchFilterFactory;
        public WebScratchService(IPageScratchFactory pageScratchFactory, ISearchFilterFactory searchFilterFactory)
        {
            _pageScratchFactory = pageScratchFactory;
            _searchFilterFactory = searchFilterFactory;
        }

        public async Task<WebDataDTO> GetWebDataDetailByFilter(SearchFilterModel searchFilter, WebSiteDTO webSiteInfo)
        {
            return new WebDataDTO()
            {
                WebSiteName = webSiteInfo.Name,
                Data = await _pageScratchFactory
                    .GetPageScratchService(searchFilter.IsHardSearch ? webSiteInfo.PageType : WebSitePageTypes.StaticPage)
                    .GetWebData(GetWebUrl(webSiteInfo.Name, searchFilter))
            };
        }

        private string GetWebUrl(WebSiteNames webSiteName, SearchFilterModel searchFilter)
        {
            return _searchFilterFactory.GetSearhFilterService(webSiteName).GetFilterUrl(searchFilter);
        }
    }
}
