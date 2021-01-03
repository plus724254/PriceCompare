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
            using var browser = await Puppeteer.ConnectAsync(new ConnectOptions()
            {
                BrowserWSEndpoint = $"wss://chrome.browserless.io?token=7220fb88-0ef3-48d0-941d-055b19dda12b&blockAds"
            });

            using var page = await browser.NewPageAsync();
            await page.GoToAsync(url, WaitUntilNavigation.DOMContentLoaded);
            var content = await page.GetContentAsync();

            //因browser以秒計費，須盡速關閉
            browser.Dispose();

            return content;
        }
    }
}
