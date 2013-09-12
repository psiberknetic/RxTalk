using System;
using System.Collections.Generic;
using System.Linq;

namespace AsynchWCFUsingTask
{
    public static class DecimalConversionExtensions
    {
        public static IEnumerable<Decimal> ConvertToDecimalList(this string inputText)
        {
            try
            {
                string[] values = inputText.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                return values.Select(Decimal.Parse);
            }
            catch
            {
                Console.WriteLine("An error occurred trying to process the input: " + inputText);
                return new List<decimal>();
            }
        }
    }
}