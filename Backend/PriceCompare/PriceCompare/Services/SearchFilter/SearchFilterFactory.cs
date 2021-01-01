using Microsoft.Extensions.DependencyInjection;
using PriceCompare.Constants.Enums;
using PriceCompare.Services.SearchFilter.PriceFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace PriceCompare.Services.SearchFilter
{
    public class SearchFilterFactory : ISearchFilterFactory
    {
        private readonly IPriceFilterFactory _priceFilterFactory;
        private readonly Dictionary<WebSiteNames, Type> _searchFilterMap = new Dictionary<WebSiteNames, Type>()
        {
            { WebSiteNames.MoMo, typeof(MoMoSearchFilterService) },
            { WebSiteNames.PChome, typeof(PChomeSearchFilterService) },
            { WebSiteNames.Yahoo, typeof(YahooSearchFilterService) },
        };

        public SearchFilterFactory(IPriceFilterFactory priceFilterFactory)
        {
            _priceFilterFactory = priceFilterFactory;
        }

        public ISearchFilterService GetSearhFilterService(WebSiteNames webSiteName)
        {
            if (_searchFilterMap.TryGetValue(webSiteName, out var searchFilter))
            {
                return (ISearchFilterService)Activator.CreateInstance(searchFilter, _priceFilterFactory);
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
