using System.Text.Json;
using PriceCompare.Helpers;
using PriceCompare.Models.DTO.Web;
using PriceCompare.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PriceCompare.Constants.Enums;

namespace PriceCompare.Services.WebSiteHtmlProcess
{
    public class PChomeDataAnalysisService : IDataAnalysisService
    {
        private const string _imagePrefix = "https://b.ecimg.tw/";
        private const string _pagePrefix = "https://24h.pchome.com.tw/prod/";
        public async Task<List<ProductViewModel>> AnalysisProductData(string webData)
        {
            try
            {
                var pchomeData = await Task.Run(() => JsonSerializer.Deserialize<PChomeDataDTO>(webData));

                return pchomeData.prods.Select(x => new ProductViewModel()
                {
                    ImageUrl = $"{_imagePrefix}{x.picB}",
                    PageUrl = $"{_pagePrefix}{x.Id}",
                    WebSiteName = nameof(WebSiteNames.PChome),
                    Name = x.name,
                    Detail = x.describe.Length > 20 ? x.describe.Substring(0, 20) : x.describe,
                    Price = x.price,
                })
                .ToList();
            }
            catch
            {
                return new List<ProductViewModel>();
            }
        }
    }
}
