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
                PageType = WebSitePageTypes.StaticPage,
            },
            new WebSiteDTO()
            {
                Name = WebSiteNames.PChome,
                DataType = WebSiteDataTypes.Json,
                PageType = WebSitePageTypes.StaticPage,
            },
            new WebSiteDTO()
            {
                Name = WebSiteNames.Yahoo,
                DataType = WebSiteDataTypes.Html,
                PageType = WebSitePageTypes.StaticPage,
            },
        };
    }
}
