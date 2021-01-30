using System;
using PriceCompare.Constants.Enums;
using PriceCompare.Services.Scratch;
using PriceCompare.Services.SearchFilter;
using PriceCompare.Services.SearchFilter.PriceFilter;
using PriceCompare.Services.WebSiteDataAnalysis;

namespace PriceCompare.Constants.WebSiteParameters
{
    public class PChomeParameters : WebSiteParameterAbstract
    {
        public PChomeParameters()
        {
            WebSiteName = WebSiteNames.PChome;
            PageScratchService = new StaticPageScratchService();
            PriceFilterService = new PChomePriceFilterService();
            SearchFilterService = new PChomeSearchFilterService();
            DataAnalysisService = new PChomeDataAnalysisService();
        }
    }
}
