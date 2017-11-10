using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace computeKClosestStars_Heap
{
    class Program
    {
        static void Main(string[] args)
        {
            //List containing all start point sitances from earth at (0,0,0).. provided as a pre-computed list of
            //sqrt(X^2 + y^2 + z^2) distance from coordinates.
            List<Double> points = new List<Double>() {21.0, 32.17, 15.43, 22.16756, 1.75433, 5.454, 45.34, 5.222, 
                4.098, 56.44, 6.4444, 1.345, 4.9876, 55.876, 45.9875 };

            int k = 4;

            MaxHeap closestKList = computeClosestKStars(points, k);

            for (int i = 0; i < k; i++)
                Console.Write(closestKList.items[i] + " ");
        }

        private static MaxHeap computeClosestKStars(List<double> points, int k)
        {
            MaxHeap closestStars = new MaxHeap();

            //Add first k points to the max heap
            for (int i = 0; i < k; i++)
                closestStars.add(points[i]);

            //Now add a point each time until list is not empty and poll a member from the max heap
            //in order to ensure that only k closest items remain in the max-heap
            int idx = k;
            while (idx < points.Count)
            {
                closestStars.add(points[idx]);

                //now remove the max-element from the max-heap
                closestStars.poll();
                idx++;
            }



            return closestStars;
        }
    }

    public class MaxHeap
    {
        public int capacity = 10;
        public int size = 0;

        public Double[] items;

        public MaxHeap()
        {
            items = new Double[capacity];
        }

        //Heap to array conversion
        public int getLeftChildIndex(int parentIndex) { return (2 * parentIndex + 1); }
        public int getRightChildIndex(int parentIndex) { return (2 * parentIndex + 2); }
        public int getParentIndex(int childIndex) { return (childIndex - 1) / 2; }

        //element exist checks
        public bool hasLeftChild(int index) { return size > getLeftChildIndex(index); }
        public bool hasRightChild(int index) { return size > getRightChildIndex(index); }
        public bool hasParent(int index) { return getParentIndex(index) >= 0; }

        //get elements
        public Double leftChild(int index) { return items[getLeftChildIndex(index)]; }
        public Double rightChild(int index) { return items[getRightChildIndex(index)]; }
        public Double parent(int index) { return items[getParentIndex(index)]; }

        public void swap(int index1, int index2)
        {
            Double temp = items[index1];
            items[index1] = items[index2];
            items[index2] = temp;
        }

        public bool isEmpty()
        {
            return size == 0;
        }

        public void ensureExtraCapacity()
        {
            if (size == capacity)
            {
                Array.Resize(ref items, capacity * 2);
                capacity *= 2;
            }
        }

        public Double peek()
        {
            if (size == 0) throw new Exception("peek() called on an Empty heap!");

            return items[0];
        }

        public Double poll()
        {
            if (size == 0) throw new Exception("poll() called on an Empty heap!");

            Double item = items[0];
            items[0] = items[size - 1];
            size--;
            heapifyDown();

            return item;
        }

        public void add(Double item)
        {
            ensureExtraCapacity(); //Resize heap array if size == capacity
            items[size] = item;
            size++;
            heapifyUp();
        }

        private void heapifyUp()
        {
            int index = size - 1;

            //swap with the parent if last element is smaller than the parent
            while (hasParent(index) && (parent(index) < items[index]))
            {
                swap(getParentIndex(index), index);
                index = getParentIndex(index);
            }
        }

        private void heapifyDown()
        {
            int index = 0;

            while (hasLeftChild(index))
            {
                int largerChildIndex = getLeftChildIndex(index);
                if (hasRightChild(index) && rightChild(index) > leftChild(index))
                    largerChildIndex = getRightChildIndex(index);

                if (items[index] > items[largerChildIndex])
                    break;
                else
                    swap(index, largerChildIndex);

                index = largerChildIndex;
            }
        }

        public void print()
        {
            foreach (Double item in items)
                Console.Write(item + " ");
        }
    }

}
