using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace computeArrayValuesThreshold
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 90, 30, 100, 40, 20 };
            Double target = 210;

            Double threshold = computeThreshold(arr, target);

            Console.Write("Threshold = " + threshold);
        }

        private static double computeThreshold(int[] arr, Double target)
        {
            Array.Sort(arr);

            Double unadjustedSum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                Double adjustedSum = arr[i] * (arr.Length - i);
                if (unadjustedSum + adjustedSum >= target)
                    return (target - unadjustedSum) / (arr.Length - i);

                unadjustedSum += arr[i];
            }

            //no solution - target > total sum (e.g. payroll)
            return -1.0;
        }
    }
}
