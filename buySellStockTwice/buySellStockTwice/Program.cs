using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace buySellStockTwice
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] a = { 12, 11, 13, 9, 12, 8, 14, 13, 15 };

            double maxProfit = maxProfitBuySellStockTwice(ref a);

            //display
            Console.WriteLine("MaxProfit = " + maxProfit.ToString());
        }

        private static double maxProfitBuySellStockTwice(ref double[] a)
        {
            double maxProfit = 0.0, minPrice = Double.MaxValue, maxProfitForward = 0.0;
            List<Double> maxProfitForwardBuySell = new List<Double>();
            
            //First phase - Forward calculation of maxProfit for ith day
            for (int i = 0; i < a.Length; i++)
            {
                minPrice = Math.Min(minPrice, a[i]);
                maxProfitForward = Math.Max(maxProfitForward, a[i] - minPrice);
                maxProfitForwardBuySell.Add(maxProfitForward);
                Console.Write(maxProfitForward + " ");
            }

            Console.WriteLine();

            Double maxProfitSoFar = Double.MinValue;
            for (int i = a.Length - 1; i > 0; i-- )
            {
                maxProfitSoFar = Math.Max(maxProfitSoFar, a[i]);
                maxProfit = Math.Max(maxProfit, maxProfitSoFar - a[i] + maxProfitForwardBuySell[i - 1]);
                Console.Write(maxProfit + " ");
            }

            return maxProfit;
        }
    }
}
