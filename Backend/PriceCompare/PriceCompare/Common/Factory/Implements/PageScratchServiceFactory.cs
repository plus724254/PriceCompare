using PriceCompare.Constants.Enums;
using PriceCompare.Services.Scratch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceCompare.Common.Factory
{
    public class PageScratchServiceFactory : IPageScratchServiceFactory
    {
        private IServiceProvider _serviceProvider;

        public PageScratchServiceFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IPageScratchService CreateInstance(WebSitePageTypes webSitePageType)
        {
            switch (webSitePageType)
            {
                case WebSitePageTypes.StaticPage:
                    return (IPageScratchService)_serviceProvider.GetService(typeof(StaticPageScratchService));

                case WebSitePageTypes.DynamicPage:
                    return (IPageScratchService)_serviceProvider.GetService(typeof(DynamicPageScratchService));

                default:
                    throw new NotSupportedException();
            }
        }
    }
}
