using PriceCompare.Constants.Enums;
using PriceCompare.Services.Scratch;

namespace PriceCompare.Common.Factory
{
    public interface IPageScratchServiceFactory
    {
        IPageScratchService CreateInstance(WebSitePageTypes webSitePageType);
    }
}