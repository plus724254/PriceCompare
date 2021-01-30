using PriceCompare.Common;
using PriceCompare.Common.Factory;
using PriceCompare.Constants.Enums;
using PriceCompare.Constants.WebSiteParameters;
using PriceCompare.Helpers;
using PriceCompare.Services.Scratch;
using PriceCompare.Services.SearchFilter;
using PriceCompare.Services.SearchFilter.PriceFilter;
using PriceCompare.Services.WebSiteDataAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceCompare.Services.Common
{
    public static class WebSiteInitialize
    {
        public static List<WebSiteSetupDTO> WebSiteSetups { get; }
        static WebSiteInitialize()
        {
            WebSiteSetups = InitializeWebSiteSetup();
        }

        private static List<WebSiteSetupDTO> InitializeWebSiteSetup()
        {
            var webSiteParameters = TypeHelper
                .GetImplementTypesFromBaseType(typeof(WebSiteParameterAbstract))
                .Where(x => !x.Name.EndsWith("Abstract"))
                .Select(x => TypeHelper.CreateInstanceByType<WebSiteParameterAbstract>(x))
                .ToList();

            var webSiteSetups = new List<WebSiteSetupDTO>();

            foreach(var webSiteParameter in webSiteParameters)
            {
                var webSiteSetup = new WebSiteSetupDTO()
                {
                    WebSiteName = webSiteParameter.WebSiteName,
                    PageScratchService = PageScratchServiceFactory.CreateInstance(webSiteParameter.WebSitePageType),
                    PriceFilterService = PriceFilterServiceFactory.CreateInstance(webSiteParameter.PriceFilterType, webSiteParameter.WebSiteName),
                    SearchFilterService = SearchFilterServiceFactory.CreateInstance(webSiteParameter.SearchFilterType, webSiteParameter.WebSiteName),
                    DataAnalysisService = DataAnalysisServiceFactory.CreateInstance(webSiteParameter.DataAnalysisType, webSiteParameter.WebSiteName),
                };

                webSiteSetups.Add(webSiteSetup);
            }

            return webSiteSetups;
        }

    }
}
