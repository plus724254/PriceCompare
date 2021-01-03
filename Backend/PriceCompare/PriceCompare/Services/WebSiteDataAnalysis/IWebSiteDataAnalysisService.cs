using PriceCompare.Constants.Enums;
using PriceCompare.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceCompare.Services.WebSiteDataAnalysis
{
    public interface IWebSiteDataAnalysisService
    {
        public void SetDataAnalysisCategory(WebSiteNames webSiteName);
        public Task<List<ProductViewModel>> GetProducts(string webData);
    }
}
