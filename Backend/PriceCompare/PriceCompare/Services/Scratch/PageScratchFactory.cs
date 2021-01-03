using Microsoft.Extensions.DependencyInjection;
using PriceCompare.Constants.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceCompare.Services.Scratch
{
    public class PageScratchFactory : IPageScratchFactory
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly Dictionary<WebSitePageTypes, Type> _pageScratchTypeMap = new Dictionary<WebSitePageTypes, Type>()
        {
            { WebSitePageTypes.StaticPage, typeof(StaticPageScratchService) },
            { WebSitePageTypes.DynamicPage, typeof(DynamicPageScratchService) },
        };

        public PageScratchFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IPageScratchService GetPageScratchService(WebSitePageTypes pageType)
        {
            if (_pageScratchTypeMap.TryGetValue(pageType, out var pageScratchType))
            {
                return (IPageScratchService)ActivatorUtilities.CreateInstance(_serviceProvider, pageScratchType);
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
