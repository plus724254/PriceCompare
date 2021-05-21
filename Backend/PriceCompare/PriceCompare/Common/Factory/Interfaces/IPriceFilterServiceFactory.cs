using PriceCompare.Constants.Enums;
using PriceCompare.Services.SearchFilter.PriceFilter;

namespace PriceCompare.Common.Factory
{
    public interface IPriceFilterServiceFactory
    {
        IPriceFilterService CreateInstance(PriceFilterTypes priceFilterType, WebSiteNames webSiteName);
    }
}