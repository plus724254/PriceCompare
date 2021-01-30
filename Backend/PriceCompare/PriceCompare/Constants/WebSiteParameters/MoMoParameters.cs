using PriceCompare.Constants.Enums;
using PriceCompare.Services.Scratch;
using PriceCompare.Services.SearchFilter;
using PriceCompare.Services.SearchFilter.PriceFilter;
using PriceCompare.Services.WebSiteDataAnalysis;

namespace PriceCompare.Constants.WebSiteParameters
{
    public class MoMoParameters : WebSiteParameterAbstract
    {
        public MoMoParameters()
        {
            WebSiteName = WebSiteNames.MoMo;
            WebSitePageType = WebSitePageTypes.DynamicPage;
            PriceFilterType = PriceFilterTypes.Common;
            SearchFilterType = SearchFilterTypes.Exclusive;
            DataAnalysisType = DataAnalysisTypes.Exclusive;
        }
    }
}
