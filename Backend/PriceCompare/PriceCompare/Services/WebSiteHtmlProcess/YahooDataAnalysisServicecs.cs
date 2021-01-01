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
            try
            {
                var document = await HtmlAnalysisHelper.GetDocument(webData);

                var products = document
                    .QuerySelectorAll(".gridList > .BaseGridItem__grid___2wuJ7")
                    .Select(x => new ProductViewModel()
                    {
                        ImageUrl = x.QuerySelector(".SquareImg_img_2gAcq").GetAttribute("srcset")?.Split(" ")[0],
                        PageUrl = x.QuerySelector("a").GetAttribute("href"),
                        WebSiteName = nameof(WebSiteNames.Yahoo),
                        Name = x.QuerySelector(".BaseGridItem__title___2HWui").InnerHtml?.Trim(),
                        Detail = string.Empty,
                        Price = WebDataConvertHelper.WebPriceToNumber(x.QuerySelector(".BaseGridItem__price___31jkj").InnerHtml) == 0 ?
                            WebDataConvertHelper.WebPriceToNumber(x.QuerySelector(".BaseGridItem__price___31jkj > em").InnerHtml)
                            : 0,
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
