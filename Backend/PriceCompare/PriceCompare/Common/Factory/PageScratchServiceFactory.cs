using PriceCompare.Constants.Enums;
using PriceCompare.Services.Scratch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceCompare.Common.Factory
{
    public static class PageScratchServiceFactory
    {
        public static IPageScratchService CreateInstance(WebSitePageTypes webSitePageType)
        {
            switch (webSitePageType)
            {
                case WebSitePageTypes.StaticPage:
                    return new StaticPageScratchService();

                case WebSitePageTypes.DynamicPage:
                    return new DynamicPageScratchService();

                default:
                    throw new NotSupportedException();
            }
        }
    }
}
