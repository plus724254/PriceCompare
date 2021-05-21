using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PriceCompare.Services.Scratch
{
    public class StaticPageScratchService : IPageScratchService
    {
        private IHttpClientFactory _httpClientFactory;

        public StaticPageScratchService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<string> GetWebData(string url)
        {
            var httpClient = _httpClientFactory.CreateClient();
            var responseMessage = await httpClient.GetAsync(url);

            if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return await responseMessage.Content.ReadAsStringAsync();//取得內容
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
