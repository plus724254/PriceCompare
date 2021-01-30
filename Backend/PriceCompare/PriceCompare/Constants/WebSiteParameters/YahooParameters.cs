using PriceCompare.Constants.Enums;
using PriceCompare.Services.Scratch;
using PriceCompare.Services.SearchFilter;
using PriceCompare.Services.SearchFilter.PriceFilter;
using PriceCompare.Services.WebSiteDataAnalysis;
namespace PriceCompare.Constants.WebSiteParameters
{
    public class YahooParameters : WebSiteParameterAbstract
    {
        public YahooParameters()
        {
            WebSiteName = WebSiteNames.Yahoo;
            PageScratchService = new StaticPageScratchService();
            PriceFilterService = new CommomPriceFilterService();
            SearchFilterService = new YahooSearchFilterService();
            DataAnalysisService = new YahooDataAnalysisService();
        }
    }
}
