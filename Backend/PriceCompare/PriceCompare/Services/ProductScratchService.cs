using PriceCompare.Constants;
using PriceCompare.Constants.WebSiteParameters;
using PriceCompare.Models;
using PriceCompare.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceCompare.Services
{
    public class ProductScratchService : IProductScratchService
    {
        private readonly IWebScratchService _webScratchService;

        public ProductScratchService(IWebScratchService webScratchService)
        {
            _webScratchService = webScratchService;
        }

        public async Task<List<ProductViewModel>> GetProducts(SearchFilterModel searchFilter)
        {
            var productViewModels = new List<ProductViewModel>();

            var tasks = WebSiteInfo.WebSites.Select(async x =>
            {
                productViewModels.AddRange(await GetProductsBySingleWebSite(searchFilter, x));
            });

            await Task.WhenAll(tasks);

            return productViewModels.OrderBy(x=>x.Price).ToList();
        }

        private async Task<List<ProductViewModel>> GetProductsBySingleWebSite(SearchFilterModel searchFilter, WebSiteParameterAbstract webSiteParameter)
        {
            var webData = await _webScratchService.GetWebDataDetailByFilter(searchFilter, webSiteParameter);

            return await webSiteParameter.DataAnalysisService.AnalysisProductData(webData.Data);
        }
    }
}
