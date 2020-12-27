using PriceCompare.Constants.Enums;
using PriceCompare.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceCompare.Constants
{
    public static class WebSiteInfo
    {
        public static WebSiteDTO[] WebSites = new WebSiteDTO[]
        {
            new WebSiteDTO()
            {
                Name = nameof(WebSiteNames.MoMo),
                SearchPrefixUrl = "https://www.momoshop.com.tw/search/searchShop.jsp?searchType=1&cateLevel=0&cateCode=&curPage=1&_isFuzzy=0&showType=chessboardType&keyword=",
            },
            new WebSiteDTO()
            {
                Name = nameof(WebSiteNames.PChome),
                SearchPrefixUrl = "https://ecshweb.pchome.com.tw/search/v3.3/?q=",
            },
            new WebSiteDTO()
            {
                Name = nameof(WebSiteNames.Yahoo),
                SearchPrefixUrl = "https://tw.buy.yahoo.com/search/product?p=",
            },
        };
    }
}
