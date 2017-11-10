using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arrayNumAddLSB
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = {2,1,9};

            a[a.Length -1]++;
            for (int i = a.Length-1; i >= 0; --i)
            {
                if (i == 0 && a[i] == 10)
                {
                    a[0] = 0;
                    Array.Resize<int>(ref a, a.Length + 1);
                    Array.Copy(a, 0, a, 1, a.Length - 2);
                    a[0] = 1;
                }

                if (a[i] == 10)
                {
                    a[i] = 0;
                    a[i - 1]++;
                }
            }

            for (int i = 0; i < a.Length; i++)
                Console.Write(a[i].ToString() + " ");
        }
    }
}
