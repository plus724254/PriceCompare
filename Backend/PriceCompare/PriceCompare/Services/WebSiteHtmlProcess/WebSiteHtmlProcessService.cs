using PriceCompare.Constants.Enums;
using PriceCompare.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceCompare.Services.WebSiteHtmlProcess
{
    public class WebSiteHtmlProcessService : IWebSiteHtmlProcessService
    {
        private readonly IWebSiteHtmlProcessFactory _webSiteHtmlProcessFactory;
        private IHtmlProcessService _htmlProcessService;
        public WebSiteHtmlProcessService(IWebSiteHtmlProcessFactory webSiteHtmlProcessFactory)
        {
            _webSiteHtmlProcessFactory = webSiteHtmlProcessFactory;
        }

        public void SetHtmlProcess(WebSiteNames webSiteName)
        {
            _htmlProcessService = _webSiteHtmlProcessFactory.GetProcessService(webSiteName);
        }

        public async Task<List<ProductViewModel>> GetProducts(string html)
        {
            return await _htmlProcessService.AnalysisProductHtml(html);
        }
    }
}
