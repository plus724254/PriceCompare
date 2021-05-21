using PriceCompare.Constants.Enums;
using PriceCompare.Services.SearchFilter;

namespace PriceCompare.Common.Factory
{
    public interface ISearchFilterServiceFactory
    {
        ISearchFilterService CreateInstance(SearchFilterTypes searchFilterType, WebSiteNames webSiteName);
    }
}