using Microsoft.Extensions.DependencyInjection;
using PriceCompare.Constants.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceCompare.Services.WebSiteDataAnalysis
{
    public class WebSiteDataAnalysisFactory : IWebSiteDataAnalysisFactory
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly Dictionary<WebSiteNames, Type> _htmlProcessMap = new Dictionary<WebSiteNames, Type>()
        {
            { WebSiteNames.MoMo, typeof(MoMoDataAnalysisService) },
            { WebSiteNames.PChome, typeof(PChomeDataAnalysisService) },
            { WebSiteNames.Yahoo, typeof(YahooDataAnalysisServicecs) },
        };

        public WebSiteDataAnalysisFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IDataAnalysisService GetAnalysisService(WebSiteNames webSiteName)
        {
            if (_htmlProcessMap.TryGetValue(webSiteName, out var htmlProcess))
            {
                return (IDataAnalysisService)ActivatorUtilities.CreateInstance(_serviceProvider, htmlProcess);
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
