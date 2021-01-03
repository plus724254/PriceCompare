using PriceCompare.Constants.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceCompare.Services.WebSiteDataAnalysis
{
    public interface IWebSiteDataAnalysisFactory
    {
        public IDataAnalysisService GetAnalysisService(WebSiteNames webSiteName);
    }
}
