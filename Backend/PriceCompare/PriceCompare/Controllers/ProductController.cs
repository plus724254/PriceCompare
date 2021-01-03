using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PriceCompare.Models;
using PriceCompare.Services;
using PriceCompare.ViewModels;

namespace PriceCompare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductScratchService _productScratchService;
        public ProductController(IProductScratchService productScratchService)
        {
            _productScratchService = productScratchService;
        }

        [HttpGet]
        public async Task<List<ProductViewModel>> Get(string keyword, int? minPrice, int? maxPrice, bool isHardSearch)
        {
            return await _productScratchService.GetProducts(new SearchFilterModel 
            { 
                Keyword = keyword, 
                MinPrice = minPrice, 
                MaxPrice = maxPrice,
                IsHardSearch = isHardSearch
            });
        }
    }
}