using PriceCompare.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceCompare.Services
{
    public interface IProductScratchService
    {
        public Task<List<ProductViewModel>> GetProducts(string productKeyword);
    }
}
