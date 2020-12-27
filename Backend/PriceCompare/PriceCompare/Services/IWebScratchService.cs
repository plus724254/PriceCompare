using PriceCompare.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceCompare.Services
{
    public interface IWebScratchService
    {
        public Task<string> GetWebHtml(string url);
        public Task<List<WebHtmlDTO>> GetWebHtmlDetailByKeyword(string searchKeyword);
    }
}
