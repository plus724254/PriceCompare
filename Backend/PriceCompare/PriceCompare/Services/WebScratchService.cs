using PriceCompare.Constants;
using PriceCompare.Constants.Enums;
using PriceCompare.Models;
using PriceCompare.Models.DTO;
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
        private readonly ISearchFilterFactory _searchFilterFactory;
        public WebScratchService(ISearchFilterFactory searchFilterFactory)
        {
            _searchFilterFactory = searchFilterFactory;
        }
        public async Task<string> GetWebData(string url)
        {
            using var httpClient = new HttpClient();

            var responseMessage = await httpClient.GetAsync(url);

            if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return responseMessage.Content.ReadAsStringAsync().Result;//取得內容
            }
            else
            {
                return string.Empty;
            }
        }

        public async Task<List<WebDataDTO>> GetWebDataDetailByFilter(SearchFilterModel searchFilter)
        {
            var webHtmls = new List<WebDataDTO>();
            var tasks = WebSiteInfo.WebSites.Select(async x => new WebDataDTO()
            {
                WebSiteName = x.Name,
                Data = await GetWebData(GetWebUrl(x.Name, searchFilter)),
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
