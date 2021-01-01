using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceCompare.Helpers
{
    public static class WebDataConvertHelper
    {
        public static int WebPriceToNumber(string priceText)
        {
            var priceTextWithoutSymbol = RemovePriceSymbol(priceText);
            int.TryParse(priceTextWithoutSymbol, out var price);

            return price;
        }

        private static string RemovePriceSymbol(string word)
        {
            if (string.IsNullOrEmpty(word))
            {
                return word;
            }

            return word.Replace("$", "").Replace(",", "");
        }
    }
}
