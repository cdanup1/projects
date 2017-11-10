using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bitMultiplication
{
    class Program
    {
        static void Main(string[] args)
        {
            long a, b, sum = 0;
            Console.WriteLine("Enter two integers for multiplication");
            long.TryParse(Console.ReadLine(), out a);
            long.TryParse(Console.ReadLine(), out b);

            while (a != 0)
            {
                if((a & 1) != 0)
                    sum = add(sum, b);

                a = a >> 1;
                b = b << 1;
            }

            Console.WriteLine("Multiplication result = " + sum.ToString() + " OR " + Convert.ToString(sum, 2));
            Console.Read();
        }

        private static long add(long sum, long b)
        {
            while(b!=0)
            {
                //Find carry bits
                long carry = sum & b;

                //Binary add without carry bits set
                sum = sum ^ b;

                //Left-shift carry word to add to sum
                b = carry << 1;
            }

            return sum;
        }
    }
}
