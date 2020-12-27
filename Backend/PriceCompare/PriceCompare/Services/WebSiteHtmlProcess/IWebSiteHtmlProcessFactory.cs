using PriceCompare.Constants.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceCompare.Services.WebSiteHtmlProcess
{
    public interface IWebSiteHtmlProcessFactory
    {
        public IHtmlProcessService GetProcessService(WebSiteNames webSiteName);
    }
}
