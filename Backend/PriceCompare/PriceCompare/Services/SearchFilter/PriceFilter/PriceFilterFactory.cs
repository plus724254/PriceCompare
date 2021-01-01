using PriceCompare.Constants.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceCompare.Services.SearchFilter.PriceFilter
{
    public class PriceFilterFactory : IPriceFilterFactory
    {
        private readonly Dictionary<WebSiteNames, Type> _priceFilterMap = new Dictionary<WebSiteNames, Type>()
        {
            { WebSiteNames.MoMo, typeof(CommomPriceFilterService) },
            { WebSiteNames.PChome, typeof(PChomePriceFilterService) },
            { WebSiteNames.Yahoo, typeof(CommomPriceFilterService) },
        };

        public IPriceFilterService GetPriceFilterService(WebSiteNames webSiteName)
        {
            if (_priceFilterMap.TryGetValue(webSiteName, out var searchFilter))
            {
                return (IPriceFilterService)Activator.CreateInstance(searchFilter);
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
