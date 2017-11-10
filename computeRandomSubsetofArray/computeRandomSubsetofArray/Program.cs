using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace computeRandomSubsetofArray
{
    class Program
    {
        /*
         * Problem: Write a program that takes an integer n, from the set {0, 1, 2, ... n-1}
         *          and size k: k<=n; and returns a random subset of k from n elements
         */
        static void Main(string[] args)
        {
            int n = 25, k = 6;

            List<int> randSubset = computeRandSubset(n, k);
            
            //display
            for (int i = 0; i < randSubset.Count; i++)
                Console.Write(randSubset[i] + " ");
        }

        private static List<int> computeRandSubset(int n, int k)
        {
            /* There are two decent solutions:
             * 1 - Use the offline sampling method to select a subset of size k from n{0,1,2,3...,n-1}
             *   - This is a O(k) time complexity and a O(n) space complexity solution
             * 2 - Use hash table to store random positions
             *   - This is a O(k) time complexity and a O9k) space complexity solution
             */
            
            List<int> randSubset = new List<int>();


            /* Solution - 1
            for (int i = 0; i < n; i++)
                randSubset.Add(i);

            Random rdmIdx = new Random();
            for (int j = 0; j < k; j++)
            {
                int randIdx = rdmIdx.Next(j, n);
                swap(ref randSubset, j, randIdx);
            }
            */


            /* Solution - 2 */
            Random rdmIdx = new Random();
            Hashtable hTable = new Hashtable(k);

            for(int i = 0; i < k; i++)
            {
                int randNum = rdmIdx.Next(i, n);
                hTable[i] = randNum;
            }


            //return randSubset.Take(k).ToList<int>();
            return hTable.Values.Cast<int>().ToList();
        }

        private static void swap(ref List<int> randSubset, int j, int randIdx)
        {
            int temp = randSubset[j];
            randSubset[j] = randSubset[randIdx];
            randSubset[randIdx] = temp;
        }
    }
}
