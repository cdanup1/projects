using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checkParity64BitWord
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("Check the parity of a 64 bit integer");

            //Random rnd = new Random();
            //int val1 = rnd.Next(), val2 = rnd.Next();
            long val = long.MaxValue;
            Console.WriteLine(Convert.ToString(val, 2));

            val ^= val >> 32;
            val ^= val >> 16;
            val ^= val >> 8;
            val ^= val >> 4;
            val ^= val >> 2;
            val ^= val >> 1;

            Console.WriteLine("Result = " + (val & 0x1).ToString());
        }

    }
}
