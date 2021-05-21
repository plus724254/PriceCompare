using PriceCompare.Constants.Enums;
using PriceCompare.Helpers;
using PriceCompare.Services.SearchFilter.PriceFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceCompare.Common.Factory
{
    public class PriceFilterServiceFactory : IPriceFilterServiceFactory
    {
        private readonly List<Type> _types;
        public PriceFilterServiceFactory()
        {
            _types = TypeHelper.GetImplementTypesFromBaseType(typeof(IPriceFilterService));
        }
        public IPriceFilterService CreateInstance(PriceFilterTypes priceFilterType, WebSiteNames webSiteName)
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
