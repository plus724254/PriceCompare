using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PriceCompare.Services.Scratch
{
    public class StaticPageScratchService : IPageScratchService
    {
        public async Task<string> GetWebData(string url)
        {
            using var httpClient = new HttpClient();
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
