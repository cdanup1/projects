using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace computeMnemonicsForPhoneNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            String number = "2021827";
            Char[] partialMnemonic = new Char[number.Length];
            List<String> mnemonics = new List<String>();

            mnemonicHelper(number, 0, partialMnemonic, ref mnemonics);

            //Display mnemonics
            foreach(String mnemonic in mnemonics)
            {
                Console.Write(mnemonic + " ");
            }
        }

        private static void mnemonicHelper(string number, int curr_digit, Char[] partialMnemonic, ref List<string> mnemonics)
        {
            //This is the last digit; and forms the complete word to be added
            if(curr_digit == number.Length)
            {
                mnemonics.Add(new String(partialMnemonic));
            }
                //Go over each digit and form words
            else
            {
                for(int i=0;i<numPad[number[curr_digit] - '0'].Length;i++)
                {
                    char c = numPad[number[curr_digit] - '0'][i];
                    partialMnemonic[curr_digit] = c;
                    mnemonicHelper(number, curr_digit + 1, partialMnemonic, ref mnemonics);
                }
            }
        }

        private static String[] numPad = {"0", "1", "ABC", "DEF", "GHI", "JKL", "MNO",
                              "PQRS", "TUV", "WXYZ"};

    }
}
