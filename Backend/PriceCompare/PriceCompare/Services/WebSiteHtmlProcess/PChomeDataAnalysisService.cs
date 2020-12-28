using PriceCompare.Helpers;
using PriceCompare.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceCompare.Services.WebSiteHtmlProcess
{
    public class PChomeDataAnalysisService : IDataAnalysisService
    {
        public async Task<List<ProductViewModel>> AnalysisProductData(string html)
        {

            var document = await HtmlAnalysisHelper.GetDocument(html);
            var productAreas = HtmlAnalysisHelper.GetAllElement(document,".col3f");

            return new List<ProductViewModel>();
        }
    }
}
