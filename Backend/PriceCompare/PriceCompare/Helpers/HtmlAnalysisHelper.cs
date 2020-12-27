using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Dom;

namespace PriceCompare.Helpers
{
    public static class HtmlAnalysisHelper
    {
        private static readonly IBrowsingContext _browsingContext;
        static  HtmlAnalysisHelper()
        {
            _browsingContext = BrowsingContext.New(Configuration.Default);
        }

        public async static Task<IDocument> GetDocument(string html)
        {
            return await _browsingContext.OpenAsync(res => res.Content(html));
        }

        public static string GetOneElement(IDocument document, string keyword)
        {
            return document.QuerySelector(keyword).ToHtml();
        }

        public static IHtmlCollection<IElement> GetAllElement(IDocument document, string keyword)
        {
            return document.QuerySelectorAll(keyword);
        }
    }
}
