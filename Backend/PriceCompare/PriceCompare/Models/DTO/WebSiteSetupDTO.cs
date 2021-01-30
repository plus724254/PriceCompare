using PriceCompare.Constants.Enums;
using PriceCompare.Services.Scratch;
using PriceCompare.Services.SearchFilter;
using PriceCompare.Services.SearchFilter.PriceFilter;
using PriceCompare.Services.WebSiteDataAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceCompare.Common
{
    public class WebSiteSetupDTO
    {
        public WebSiteNames WebSiteName { get; set; } 
        public IPageScratchService PageScratchService { get; set; }
        public IPriceFilterService PriceFilterService { get; set; }
        public ISearchFilterService SearchFilterService { get; set; }
        public IDataAnalysisService DataAnalysisService { get; set; }
    }
}
