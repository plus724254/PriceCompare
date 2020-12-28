using PriceCompare.Constants;
using PriceCompare.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PriceCompare.Services
{
    public class WebScratchService : IWebScratchService
    {
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

        public async Task<List<WebDataDTO>> GetWebDataDetailByKeyword(string searchKeyword)
        {
            var webHtmls = new List<WebDataDTO>();
            var tasks = WebSiteInfo.WebSites.Select(async x => new WebDataDTO()
            {
                WebSiteName = x.Name,
                Data = await GetWebData(x.SearchPrefixUrl + searchKeyword),
            });

            var result = await Task.WhenAll(tasks);

            return result.ToList();
        }
    }
}
