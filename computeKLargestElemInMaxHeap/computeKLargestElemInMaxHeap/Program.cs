using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace computeKLargestElemInMaxHeap
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = new int[] { 561, 314, 401, 28, 156, 359, 271, 11, 3 };
            int k = 4;

            List<int> largestKElem = findKLargestInMaxHeap(A, k);

            foreach (int item in largestKElem)
                Console.Write(item + " ");
        }

        private static List<int> findKLargestInMaxHeap(int[] A, int k)
        {
            if (A.Length < k)
                throw new Exception("ERROR -- K is smaller than the size of the max-heap");
            if (A.Length == 0)
                return null;

            List<int> result = new List<int>();
            MaxHeap maxHeap = new MaxHeap();
            maxHeap.add(A[0]);

            for(int i = 0; i < k; i++)
            {
                int leftChildIdx = 2 * i + 1, rightChildIdx = 2 * i + 2;
                result.Add(maxHeap.poll());

                if(leftChildIdx < A.Length)
                    maxHeap.add(A[leftChildIdx]);
                if (rightChildIdx < A.Length)
                    maxHeap.add(A[rightChildIdx]);
            }

            return result;
        }
    }

    public class MaxHeap
    {
        public int capacity = 10;
        public int size = 0;

        public int[] items;

        public MaxHeap()
        {
            items = new int[capacity];
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
        public int leftChild(int index) { return items[getLeftChildIndex(index)]; }
        public int rightChild(int index) { return items[getRightChildIndex(index)]; }
        public int parent(int index) { return items[getParentIndex(index)]; }

        public void swap(int index1, int index2)
        {
            int temp = items[index1];
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

        public int peek()
        {
            if (size == 0) throw new Exception("peek() called on an Empty heap!");

            return items[0];
        }

        public int poll()
        {
            if (size == 0) throw new Exception("poll() called on an Empty heap!");

            int item = items[0];
            items[0] = items[size - 1];
            size--;
            heapifyDown();

            return item;
        }

        public void add(int item)
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
            foreach (int item in items)
                Console.Write(item + " ");
        }
    }


}
