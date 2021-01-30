using PriceCompare.Constants.Enums;
using PriceCompare.Helpers;
using PriceCompare.Services.SearchFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace PriceCompare.Common.Factory
{
    public static class SearchFilterServiceFactory
    {
        private static readonly List<Type> _types;
        static SearchFilterServiceFactory()
        {
            _types = TypeHelper.GetImplementTypesFromInterface(typeof(ISearchFilterService));
        }

        public static ISearchFilterService CreateInstance(SearchFilterTypes searchFilterType, WebSiteNames webSiteName)
        {
            switch (searchFilterType)
            {
                case SearchFilterTypes.Exclusive:
                    var type = _types.First(x => x.Name.StartsWith(webSiteName.ToString()));
                    return TypeHelper.CreateInstanceByType<ISearchFilterService>(type);

                default:
                    throw new NotSupportedException();
            }
        }
    }
}
