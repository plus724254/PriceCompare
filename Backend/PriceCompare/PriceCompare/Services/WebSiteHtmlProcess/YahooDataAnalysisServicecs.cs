using PriceCompare.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceCompare.Services.WebSiteHtmlProcess
{
    public class YahooDataAnalysisServicecs : IDataAnalysisService
    {
        public async Task<List<ProductViewModel>> AnalysisProductData(string html)
        {
            return await Task.Run(() => new List<ProductViewModel>());
        }
    }
}
