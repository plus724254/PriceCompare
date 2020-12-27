using PriceCompare.Constants.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceCompare.Services.WebSiteHtmlProcess
{
    public class WebSiteHtmlProcessFactory : IWebSiteHtmlProcessFactory
    {
        private readonly Dictionary<WebSiteNames, Type> _htmlProcessMap = new Dictionary<WebSiteNames, Type>()
        {
            { WebSiteNames.MoMo, typeof(MoMoHtmlProcessService) },
            { WebSiteNames.PChome, typeof(PChomeHtmlProcessService) },
            { WebSiteNames.Yahoo, typeof(YahooHtmlProcessServicecs) },
        };

        public IHtmlProcessService GetProcessService(WebSiteNames webSiteName)
        {
            if (_htmlProcessMap.TryGetValue(webSiteName, out var htmlProcess))
            {
                return (IHtmlProcessService)Activator.CreateInstance(htmlProcess);
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
