using PriceCompare.Constants.Enums;
using PriceCompare.Helpers;
using PriceCompare.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceCompare.Services.WebSiteHtmlProcess
{
    public class YahooDataAnalysisServicecs : IDataAnalysisService
    {
        public async Task<List<ProductViewModel>> AnalysisProductData(string webData)
        {
            var document = await HtmlAnalysisHelper.GetDocument(webData);

            var products = document
                .QuerySelectorAll(".gridList > .BaseGridItem__grid___2wuJ7")
                .Select(x => new ProductViewModel()
                {
                    ImageUrl = x.QuerySelector(".SquareFence_wrap_3jTo2").GetAttribute("src"),
                    PageUrl = x.QuerySelector("a").GetAttribute("href"),
                    WebSiteName = nameof(WebSiteNames.Yahoo),
                    Name = x.QuerySelector(".BaseGridItem__title___2HWui").InnerHtml?.Trim(),
                    Detail = string.Empty,
                    Price = WebDataConvertHelper.WebPriceToNumber(x.QuerySelector(".BaseGridItem__price___31jkj").InnerHtml),
                })
                .ToList();

            return products;
        }
    }
}
