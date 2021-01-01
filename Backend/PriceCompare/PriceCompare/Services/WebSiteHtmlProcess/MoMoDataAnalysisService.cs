using PriceCompare.Constants.Enums;
using PriceCompare.Helpers;
using PriceCompare.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceCompare.Services.WebSiteHtmlProcess
{
    public class MoMoDataAnalysisService : IDataAnalysisService
    {
        private const string _pagePrefix = "http://m.momoshop.com.tw/";
        public async Task<List<ProductViewModel>> AnalysisProductData(string webData)
        {
            try
            {
                var document = await HtmlAnalysisHelper.GetDocument(webData);

                var products = document
                    .QuerySelectorAll(".goodsItemLi")
                    .Select(x => new ProductViewModel()
                    {
                        ImageUrl = x.QuerySelector(".prdImgWrap > img").GetAttribute("src"),
                        PageUrl = x.QuerySelector("a").GetAttribute("href"),
                        WebSiteName = nameof(WebSiteNames.MoMo),
                        Name = x.QuerySelector(".prdInfoWrap > .prdName").InnerHtml?.Trim(),
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
