using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace computeNextArrayPermutation
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> array = new List<int> { 6, 2, 1, 5, 4, 3, 0 };
            computeNextPermutation(ref array);
            //display
            for (int i = 0; i < array.Count; i++)
                Console.Write(array[i] + " ");
        }

        private static void computeNextPermutation(ref List<int> array)
        {
            /* Find the largest array suffix of decreasing order */
            int k = array.Count - 2; //last index of array
            while (k >= 0 && array[k] > array[k + 1])
                k--;

            //If this is the last permutation; the List is empty
            if (k == -1)
                array.Clear();

            /* In decreasing suffix, find an element to swap that is smallest in the suffix, 
             * but larger than the element preceeding the suffix.
             * -- Use the fact that the decreasing ordered suffix is sorted already */
            for(int i = array.Count - 1; i > k; i--)
            {
                if(array[i] > array[k])
                {
                    int temp = array[k];
                    array[k] = array[i];
                    array[i] = temp;
                    break;
                }
            }

            /* Now reverse the order of the new swapped suffix */
            array.Reverse(k + 1, array.Count - k - 1);
        }
    }
}
