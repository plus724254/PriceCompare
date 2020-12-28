using PriceCompare.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceCompare.Services.WebSiteHtmlProcess
{
    public interface IDataAnalysisService
    {
        public Task<List<ProductViewModel>> AnalysisProductData(string html);
    }
}
