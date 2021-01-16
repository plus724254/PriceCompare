using PriceCompare.Constants;
using PriceCompare.Models;
using PriceCompare.Models.DTO;
using PriceCompare.Services.WebSiteDataAnalysis;
using PriceCompare.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceCompare.Services
{
    public class ProductScratchService : IProductScratchService
    {
        private readonly IWebScratchService _webScratchService;
        private readonly IWebSiteDataAnalysisService _webSiteDataAnalysisService;
        public ProductScratchService(IWebScratchService webScratchService, IWebSiteDataAnalysisService webSiteDataAnalysisService)
        {
            _webScratchService = webScratchService;
            _webSiteDataAnalysisService = webSiteDataAnalysisService;
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

        private async Task<List<ProductViewModel>> GetProductsBySingleWebSite(SearchFilterModel searchFilter, WebSiteDTO webSiteDTO)
        {
            var webData = await _webScratchService.GetWebDataDetailByFilter(searchFilter, webSiteDTO);
            _webSiteDataAnalysisService.SetDataAnalysisCategory(webData.WebSiteName);

            return await _webSiteDataAnalysisService.GetProducts(webData.Data);
        }
    }
}
