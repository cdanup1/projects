using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binSearchComputeIntegerSquareRoot
{
    class Program
    {
        static void Main(string[] args)
        {   /*
             * Write a program which takes a nonnegative integer and returns the largest integer
             * whose square is less than or equal to the given integer. For example, if the input is
             * 16, return 4; if the input is 300, return 17, since 17^2 = 289 < 300 and 18^2 = 324 > 300.
             */
            int k = 300;
            int largestIntSquareLessThanK = computeLargestIntSquareLessThanK(k);

            Console.WriteLine(largestIntSquareLessThanK);
        }

        private static int computeLargestIntSquareLessThanK(int k)
        {
            int L = 0, U = k, M = 0;

            while(L < U)
            {
                M = L + (U-L)/2;
                if ((M * M) < k)
                    L = M + 1;
                else
                    U = M - 1;
            }

            return L - 1;
        }
    }
}
