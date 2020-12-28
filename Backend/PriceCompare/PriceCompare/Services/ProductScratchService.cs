using PriceCompare.Constants;
using PriceCompare.Models.DTO;
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
        public ProductScratchService(IWebScratchService webScratchService)
        {
            _webScratchService = webScratchService;
        }

        public async Task<List<ProductViewModel>> GetProducts(string productKeyword)
        {
            var webDataInfos = await _webScratchService.GetWebDataDetailByKeyword(productKeyword);
            var productViewModels = Enumerable.Empty<List<ProductViewModel>>();


            foreach(var webDataInfo in webDataInfos)
            {

            }






            return new List<ProductViewModel>()
            {
                new ProductViewModel()
                {
                    ImageUrl = "https://img1.momoshop.com.tw/goodsimg/0007/591/708/7591708_L.jpg?t=1608347766",
                    PageUrl = "/goods/GoodsDetail.jsp?i_code=7591708&Area=search&mdiv=403&oid=1_1&cid=index&kw=wa500",
                    Name = "聲寶qa500 QLED",
                    Detail = "測試",
                    Price = "29900",
                },
                new ProductViewModel()
                {
                    ImageUrl = "https://b.ecimg.tw/items/DPADTPA900AOPJ7/000002_1591243426.jpg",
                    PageUrl = "https://24h.pchome.com.tw/prod/DPADTP-A900AOPJ7",
                    Name = "聲寶55吋電視qa500 QLED",
                    Detail = "測測試試",
                    Price = "39900",
                },
            };
        }
    }
}
