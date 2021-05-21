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
    public class WebSiteInitialize
    {
        public List<WebSiteSetupDTO> WebSiteSetups { get; }

        private readonly IPageScratchServiceFactory _pageScratchServiceFactory;
        private readonly IPriceFilterServiceFactory _priceFilterServiceFactory;
        private readonly ISearchFilterServiceFactory _searchFilterServiceFactory;
        private readonly IDataAnalysisServiceFactory _dataAnalysisServiceFactory;

        public WebSiteInitialize(
            IPageScratchServiceFactory pageScratchServiceFactory,
            IPriceFilterServiceFactory priceFilterServiceFactory,
            ISearchFilterServiceFactory searchFilterServiceFactory,
            IDataAnalysisServiceFactory dataAnalysisServiceFactory)
        {
            _pageScratchServiceFactory = pageScratchServiceFactory;
            _priceFilterServiceFactory = priceFilterServiceFactory;
            _searchFilterServiceFactory = searchFilterServiceFactory;
            _dataAnalysisServiceFactory = dataAnalysisServiceFactory;

            WebSiteSetups = InitializeWebSiteSetup();
        }

        private List<WebSiteSetupDTO> InitializeWebSiteSetup()
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
                    PageScratchService = _pageScratchServiceFactory.CreateInstance(webSiteParameter.WebSitePageType),
                    PriceFilterService = _priceFilterServiceFactory.CreateInstance(webSiteParameter.PriceFilterType, webSiteParameter.WebSiteName),
                    SearchFilterService = _searchFilterServiceFactory.CreateInstance(webSiteParameter.SearchFilterType, webSiteParameter.WebSiteName),
                    DataAnalysisService = _dataAnalysisServiceFactory.CreateInstance(webSiteParameter.DataAnalysisType, webSiteParameter.WebSiteName),
                };

                webSiteSetups.Add(webSiteSetup);
            }

            return webSiteSetups;
        }
    }
}
