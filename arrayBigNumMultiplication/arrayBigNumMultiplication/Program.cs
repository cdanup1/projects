using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arrayBigNumMultiplication
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = { 1, 2, 3, 4, 5, 6, 7 };
            int[] b = { 7, 6, 5, 4, 3, 2, 0 };

            int[] result = new int[a.Length + b.Length];

            for (int i = a.Length - 1; i >= 0; --i)
            {
                for (int j = b.Length - 1; j >= 0; --j)
                {
                    result[i + j + 1] += a[i] * b[j];
                    result[i + j] += (result[i + j + 1] / 10);
                    result[i + j + 1] %= 10;
                }
            }

            // Remove leading zeros
            int nZeros = 0;
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] == 0)
                {
                    nZeros++;
                }
                else
                    break;
            }

            int[] multi = new int[result.Length - nZeros];
            Array.Copy(result, nZeros, multi, 0, result.Length - nZeros);
            
            //display
            for (int i = 0; i < multi.Length; i++)
            {
                Console.Write(multi[i] + " ");
            }
        }
    }
}
