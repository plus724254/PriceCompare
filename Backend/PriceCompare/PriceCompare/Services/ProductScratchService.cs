using PriceCompare.Constants;
using PriceCompare.Models.DTO;
using PriceCompare.Services.WebSiteHtmlProcess;
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

        public async Task<List<ProductViewModel>> GetProducts(string productKeyword)
        {
            var webDataInfos = await _webScratchService.GetWebDataDetailByKeyword(productKeyword);
            var productViewModels = new List<ProductViewModel>();


            var tasks = webDataInfos.Select(async x => 
            {
                _webSiteDataAnalysisService.SetDataAnalysisCategory(x.WebSiteName);
                productViewModels.AddRange(await _webSiteDataAnalysisService.GetProducts(x.Data));
            });

            await Task.WhenAll(tasks);

            return productViewModels.OrderBy(x=>x.Price).ToList();
        }
    }
}
