using PriceCompare.Constants.Enums;
using PriceCompare.Helpers;
using PriceCompare.Services.SearchFilter.PriceFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceCompare.Common.Factory
{
    public static class PriceFilterServiceFactory
    {
        private static readonly List<Type> _types;
        static PriceFilterServiceFactory()
        {
            _types = TypeHelper.GetImplementTypesFromBaseType(typeof(IPriceFilterService));
        }
        public static IPriceFilterService CreateInstance(PriceFilterTypes priceFilterType, WebSiteNames webSiteName)
        {
            switch (priceFilterType)
            {
                case PriceFilterTypes.Common:
                    return new CommomPriceFilterService();

                case PriceFilterTypes.Exclusive:
                    var type = _types.First(x => x.Name.StartsWith(webSiteName.ToString()));
                    return TypeHelper.CreateInstanceByType<IPriceFilterService>(type);

                default:
                    throw new NotSupportedException();
            }
        }
    }
}
