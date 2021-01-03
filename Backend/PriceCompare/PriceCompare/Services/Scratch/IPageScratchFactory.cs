using PriceCompare.Constants.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceCompare.Services.Scratch
{
    public interface IPageScratchFactory
    {
        IPageScratchService GetPageScratchService(WebSitePageTypes pageType);
    }
}
