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

        public async Task<List<WebDataDTO>> GetWebDataDetailByFilter(SearchFilterModel searchFilter)
        {
            var webHtmls = new List<WebDataDTO>();
            var tasks = WebSiteInfo.WebSites.Select(async x => new WebDataDTO()
            {
                WebSiteName = x.Name,
                Data = await _pageScratchFactory
                    .GetPageScratchService(searchFilter.IsHardSearch? x.PageType : WebSitePageTypes.StaticPage)
                    .GetWebData(GetWebUrl(x.Name, searchFilter))
            });

            var result = await Task.WhenAll(tasks);
            
            return result.ToList();
        }

        private string GetWebUrl(WebSiteNames webSiteName, SearchFilterModel searchFilter)
        {
            return _searchFilterFactory.GetSearhFilterService(webSiteName).GetFilterUrl(searchFilter);
        }
    }
}
