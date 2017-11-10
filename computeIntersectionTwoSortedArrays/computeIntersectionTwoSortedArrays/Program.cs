using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace computeIntersectionTwoSortedArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> A = new List<int>() { 2, 3, 3, 5, 7, 11 };
            List<int> B = new List<int>() { 3, 3, 7, 15, 31 };

            List<int> intersect = computeIntersection(A, B);

            foreach (int item in intersect)
                Console.Write(item + " ");

        }

        //Linear O(n+m) solution
        private static List<int> computeIntersection(List<int> A, List<int> B)
        {
            List<int> intersection = new List<int>();
            while (A.Count > 0 && B.Count > 0)
            {
                if (A[0] < B[0])
                    A.RemoveAt(0);
                else if (B[0] < A[0])
                    B.RemoveAt(0);
                else
                {
                    if (intersection.Count == 0 || intersection.Last() != A[0])
                        intersection.Add(A[0]);
                    A.RemoveAt(0); B.RemoveAt(0);
                }
            }

            return intersection;
        }
    }
}
