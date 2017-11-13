using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace convertRomanNumStringToInt
{
    class Program
    {
        static void Main(string[] args)
        {
            String romanNum = "CDXXIV";

            int num = convertRomanNumToInt(romanNum);

            //disp
            Console.WriteLine(num);
        }

        private static Dictionary<Char, Int32> T = new Dictionary<Char, Int32>()
        {
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000}
        };

        private static int convertRomanNumToInt(string romanNum)
        {
            int sum = T[romanNum[romanNum.Length-1]];

            for (int i = romanNum.Length - 2; i >= 0; i--)
            {
                if (T[romanNum[i]] < T[romanNum[i + 1]])
                    sum -= T[romanNum[i]];
                else
                    sum += T[romanNum[i]];
            }

            return sum;
        }
    }
}
