using PriceCompare.Constants.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceCompare.Services.WebSiteHtmlProcess
{
    public class WebSiteDataAnalysisFactory : IWebSiteDataAnalysisFactory
    {
        private readonly Dictionary<WebSiteNames, Type> _htmlProcessMap = new Dictionary<WebSiteNames, Type>()
        {
            { WebSiteNames.MoMo, typeof(MoMoDataAnalysisService) },
            { WebSiteNames.PChome, typeof(PChomeDataAnalysisService) },
            { WebSiteNames.Yahoo, typeof(YahooDataAnalysisServicecs) },
        };

        public IDataAnalysisService GetAnalysisService(WebSiteNames webSiteName)
        {
            if (_htmlProcessMap.TryGetValue(webSiteName, out var htmlProcess))
            {
                return (IDataAnalysisService)Activator.CreateInstance(htmlProcess);
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
