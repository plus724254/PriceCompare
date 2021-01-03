using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceCompare.Services.Scratch
{
    public interface IPageScratchService
    {
        Task<string> GetWebData(string url);
    }
}
