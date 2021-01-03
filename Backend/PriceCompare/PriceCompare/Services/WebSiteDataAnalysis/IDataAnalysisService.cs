using PriceCompare.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceCompare.Services.WebSiteDataAnalysis
{
    public interface IDataAnalysisService
    {
        public Task<List<ProductViewModel>> AnalysisProductData(string webData);
    }
}
