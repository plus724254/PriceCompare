using PriceCompare.Constants.Enums;
using PriceCompare.Services.Scratch;
using PriceCompare.Services.SearchFilter;
using PriceCompare.Services.SearchFilter.PriceFilter;
using PriceCompare.Services.WebSiteDataAnalysis;

namespace PriceCompare.Constants.WebSiteParameters
{
    public class WebSiteParameterAbstract
    {
        public WebSiteNames WebSiteName { get; set; }
        public WebSitePageTypes WebSitePageType { get; set; }
        public PriceFilterTypes PriceFilterType { get; set; }
        public SearchFilterTypes SearchFilterType { get; set; }
        public DataAnalysisTypes DataAnalysisType { get; set; }
    }
}
