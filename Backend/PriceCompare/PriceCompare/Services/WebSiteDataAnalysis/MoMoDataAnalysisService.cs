using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PriceCompare.Constants.Enums;
using PriceCompare.Helpers;
using PriceCompare.ViewModels;

namespace PriceCompare.Services.WebSiteDataAnalysis
{
    public class MoMoDataAnalysisService : IDataAnalysisService
    {
        private const string _pagePrefix = "https://m.momoshop.com.tw";
        public async Task<List<ProductViewModel>> AnalysisProductData(string webData)
        {
            try
            {
                var document = await HtmlAnalysisHelper.GetDocument(webData);

                var products = document
                    .QuerySelectorAll(".goodsItemLi")
                    .Select(x => new ProductViewModel()
                    {
                        ImageUrl = x.QuerySelector(".prdImgWrap .goodsImg")?.GetAttribute("data-original") ?? string.Empty,
                        PageUrl = $"{_pagePrefix}{x.QuerySelector("a").GetAttribute("href")}",
                        WebSiteName = nameof(WebSiteNames.MoMo),
                        Name = x.QuerySelector(".prdInfoWrap .prdName")?.InnerHtml?.Trim(),
                        Detail = string.Empty,
                        Price = WebDataConvertHelper.WebPriceToNumber(x.QuerySelector(".priceSymbol > .price").InnerHtml),
                    })
                    .ToList();

                return products;
            }
            catch
            {
                return new List<ProductViewModel>();
            }
        }
    }
}
