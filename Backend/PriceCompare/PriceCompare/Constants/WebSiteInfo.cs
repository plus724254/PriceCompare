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
        public static readonly WebSiteDTO[] WebSites = new WebSiteDTO[]
        {
            new WebSiteDTO()
            {
                Name = WebSiteNames.MoMo,
                DataType = WebSiteDataTypes.Html,
                SearchPrefixUrl = "http://m.momoshop.com.tw/search.momo?couponSeq=&cpName=&searchType=1&cateLevel=-1&cateCode=-1&ent=k&_imgSH=fourCardStyle&searchKeyword=",
            },
            new WebSiteDTO()
            {
                Name = WebSiteNames.PChome,
                DataType = WebSiteDataTypes.Json,
                SearchPrefixUrl = "https://ecshweb.pchome.com.tw/search/v3.3/all/results?page=1&sort=sale/dc&q=",
            },
            new WebSiteDTO()
            {
                Name = WebSiteNames.Yahoo,
                DataType = WebSiteDataTypes.Html,
                SearchPrefixUrl = "https://tw.buy.yahoo.com/search/product?p=",
            },
        };
    }
}
