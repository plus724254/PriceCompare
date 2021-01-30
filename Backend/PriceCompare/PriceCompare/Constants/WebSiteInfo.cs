using PriceCompare.Constants.WebSiteParameters;
using System.Collections.Generic;

namespace PriceCompare.Constants
{
    public static class WebSiteInfo
    {
        public static readonly List<WebSiteParameterAbstract> WebSites = new List<WebSiteParameterAbstract>
        {
            new MoMoParameters(),
            new PChomeParameters(),
            new YahooParameters(),
        };
    }
}
