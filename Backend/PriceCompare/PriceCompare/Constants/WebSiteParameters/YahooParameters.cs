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
            WebSitePageType = WebSitePageTypes.StaticPage;
            PriceFilterType = PriceFilterTypes.Common;
            SearchFilterType = SearchFilterTypes.Exclusive;
            DataAnalysisType = DataAnalysisTypes.Exclusive;
        }
    }
}
