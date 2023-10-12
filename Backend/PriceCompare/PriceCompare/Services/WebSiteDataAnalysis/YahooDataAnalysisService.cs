using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngleSharp.Dom;
using PriceCompare.Constants.Enums;
using PriceCompare.Helpers;
using PriceCompare.ViewModels;

namespace PriceCompare.Services.WebSiteDataAnalysis
{
    public class YahooDataAnalysisService : IDataAnalysisService
    {
        public async Task<List<ProductViewModel>> AnalysisProductData(string webData)
        {
            try
            {
                var document = await HtmlAnalysisHelper.GetDocument(webData);

                var products = document
                    .QuerySelectorAll(".ResultList_resultList_IpWJt > .gridList > .sc-1drl28c-1")
                    .Select(x => new ProductViewModel()
                     {
                         ImageUrl = x.QuerySelector(".sc-1mbu11z-0")?.GetAttribute("src"),
                         PageUrl = x?.GetAttribute("href"),
                         WebSiteName = nameof(WebSiteNames.Yahoo),
                         Name = x.QuerySelector(".sc-1drl28c-4 > span")?.InnerHtml?.Trim(),
                         Detail = string.Empty,
                         Price = GetPrice(x),
                     })
                    .ToList();

                return products;
            }
            catch
            {
                return new List<ProductViewModel>();
            }
        }

        private int GetPrice(IElement element)
        {
            var scratchPrice = WebDataConvertHelper.WebPriceToNumber(element.QuerySelector(".sc-1ap2njs-0 .sc-1d7r8jg-0").InnerHtml);

            //if(scratchPrice != 0)
            //{
                return scratchPrice;
            //}
            //else
            //{
            //    return WebDataConvertHelper.WebPriceToNumber(element.QuerySelector(".BaseGridItem__price___31jkj > em").InnerHtml);
            //}
        }
    }
}
