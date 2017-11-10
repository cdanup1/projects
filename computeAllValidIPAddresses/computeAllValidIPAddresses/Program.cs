using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace computeAllValidIPAddresses
{
    class Program
    {
        static void Main(string[] args)
        {
            String ipStr = "19216811";
            List<String> validIPs = new List<String>();

            getAllValidIPAddresses(ipStr, validIPs);

            //Display
            foreach (String IPAddress in validIPs)
            {
                Console.WriteLine(IPAddress);
            }
        }

        private static void getAllValidIPAddresses(string ipStr, List<string> validIPs)
        {
            for (int i = 1; i < 4; i++)
                if (isValid(ipStr.Substring(0, i)))
                    for (int j = 1; j < 4 && i+j<ipStr.Length; j++)
                        if (isValid(ipStr.Substring(i, j)))
                            for (int k = 1; k < 4 && i + j+k < ipStr.Length; k++)
                                if (isValid(ipStr.Substring(i + j, k)))
                                    for (int l = 1; l < 4 && i + j +k+l-1< ipStr.Length; l++)
                                        if (isValid(ipStr.Substring(i + j + k, l)))
                                            if ((ipStr.Substring(0, i) + ipStr.Substring(i, j) + ipStr.Substring(i + j, k) + ipStr.Substring(i + j + k, l)).Length == ipStr.Length)
                                                validIPs.Add(ipStr.Substring(0, i) + "." + ipStr.Substring(i, j) + "." + ipStr.Substring(i + j, k)
                                                    + "." + ipStr.Substring(i + j + k, l));
        }

        private static bool isValid(string p)
        {
            int num = Convert.ToInt32(p);

            if (num >= 0 && num <= 255)
                return true;
            else return false;
        }
    }
}
