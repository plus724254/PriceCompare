using PriceCompare.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceCompare.Services.WebSiteHtmlProcess
{
    public interface IHtmlProcessService
    {
        public Task<List<ProductViewModel>> AnalysisProductHtml(string html);
    }
}
