﻿using PriceCompare.Common;
using PriceCompare.Constants;
using PriceCompare.Constants.WebSiteParameters;
using PriceCompare.Models;
using PriceCompare.Services.Common;
using PriceCompare.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceCompare.Services
{
    public class ProductScratchService : IProductScratchService
    {
        private readonly IWebScratchService _webScratchService;
        private readonly WebSiteInitialize _webSiteInitialize;

        public ProductScratchService(IWebScratchService webScratchService, WebSiteInitialize webSiteInitialize)
        {
            _webScratchService = webScratchService;
            _webSiteInitialize = webSiteInitialize;
        }

        public async Task<List<ProductViewModel>> GetProducts(SearchFilterModel searchFilter)
        {
            var productViewModels = new List<ProductViewModel>();

            var tasks = _webSiteInitialize.WebSiteSetups.Select(async x =>
            {
                productViewModels.AddRange(await GetProductsBySingleWebSite(searchFilter, x));
            });

            await Task.WhenAll(tasks);

            return productViewModels.OrderBy(x=>x.Price).ToList();
        }

        private async Task<List<ProductViewModel>> GetProductsBySingleWebSite(SearchFilterModel searchFilter, WebSiteSetupDTO webSiteSetup)
        {
            var webData = await _webScratchService.GetWebDataDetailByFilter(searchFilter, webSiteSetup);

            return await webSiteSetup.DataAnalysisService.AnalysisProductData(webData.Data);
        }
    }
}
