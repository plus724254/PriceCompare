using PuppeteerSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceCompare.Services.Scratch
{
    public class DynamicPageScratchService : IPageScratchService
    {
        public async Task<string> GetWebData(string url)
        {
            await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision);
            using var browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = true
            });

            using var page = await browser.NewPageAsync();
            await page.GoToAsync(url);

            return await page.GetContentAsync();   
        }
    }
}
