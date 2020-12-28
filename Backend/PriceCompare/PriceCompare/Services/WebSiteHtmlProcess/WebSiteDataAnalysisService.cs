using PriceCompare.Constants.Enums;
using PriceCompare.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceCompare.Services.WebSiteHtmlProcess
{
    public class WebSiteDataAnalysisService : IWebSiteDataAnalysisService
    {
        private readonly IWebSiteDataAnalysisFactory _webSiteHtmlProcessFactory;
        private IDataAnalysisService _htmlProcessService;
        public WebSiteDataAnalysisService(IWebSiteDataAnalysisFactory webSiteHtmlProcessFactory)
        {
            _webSiteHtmlProcessFactory = webSiteHtmlProcessFactory;
        }

        public void SetDataAnalysisCategory(WebSiteNames webSiteName)
        {
            _htmlProcessService = _webSiteHtmlProcessFactory.GetAnalysisService(webSiteName);
        }

        public async Task<List<ProductViewModel>> GetProducts(string webData)
        {
            return await _htmlProcessService.AnalysisProductData(webData);
        }
    }
}
