using PriceCompare.Constants.Enums;

namespace PriceCompare.Constants.WebSiteParameters
{
    public class PChomeParameters : WebSiteParameterAbstract
    {
        public PChomeParameters()
        {
            WebSiteName = WebSiteNames.PChome;
            WebSitePageType = WebSitePageTypes.StaticPage;
            PriceFilterType = PriceFilterTypes.Exclusive;
            SearchFilterType = SearchFilterTypes.Exclusive;
            DataAnalysisType = DataAnalysisTypes.Exclusive;
        }
    }
}
