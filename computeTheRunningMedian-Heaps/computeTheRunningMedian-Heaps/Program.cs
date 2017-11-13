using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace computeTheRunningMedian_Heaps
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> entries = new List<int>() { 1, 0, 3, 5, 2, 0, 1 };

            List<Double> median = computeRunningMedian(entries);

            foreach (Double value in median)
                Console.Write(value + " ");
        }

        private static List<Double> computeRunningMedian(List<int> entries)
        {
            //Init min-heap & max-heap
            //minheap helps store the set of values greater than the median
            //maxheap helps store the set of values lesser than the median
            MinHeap minheap = new MinHeap(); //helps keep track of minimum of values greater than the median
            MaxHeap maxheap = new MaxHeap(); //helps keep track of maximum of values smaller than the median

            List<Double> medianEntries = new List<Double>();
            Double runningMedian;
            int currentIdx = 0;

            //initial values
            //add the bigger value in minHeap
            if (entries[0] > entries[1])
            {
                minheap.add(entries[0]);
                maxheap.add(entries[1]);
            }
            else
            {
                minheap.add(entries[1]);
                maxheap.add(entries[0]);
            }

            medianEntries.Add(entries[0]);
            medianEntries.Add((Double)(minheap.peek() + maxheap.peek()) / 2);
            runningMedian = medianEntries[1];

            currentIdx = 2;

            while(currentIdx < entries.Count)
            {
                if (entries[currentIdx] > runningMedian)
                    minheap.add(entries[currentIdx]);
                else
                    maxheap.add(entries[currentIdx]);

                //rebalance heaps whenever the size difference is > 1
                if(Math.Abs(minheap.size-maxheap.size)>1)
                {
                    if (minheap.size > maxheap.size) maxheap.add(minheap.poll());
                    else minheap.add(maxheap.poll());
                }

                if (minheap.size != maxheap.size)
                    if (minheap.size > maxheap.size)
                        medianEntries.Add(minheap.peek());
                    else
                        medianEntries.Add(maxheap.peek());
                else
                    medianEntries.Add((Double)(minheap.peek() + maxheap.peek()) / 2);

                runningMedian = medianEntries[currentIdx];
                currentIdx++;
            }

            return medianEntries;

        }
    }

    public class MinHeap
    {
        public int capacity = 10;
        public int size = 0;

        public int[] items;

        public MinHeap()
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
            while (hasParent(index) && (parent(index) > items[index]))
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
                int smallerChildIndex = getLeftChildIndex(index);
                if (hasRightChild(index) && rightChild(index) < leftChild(index))
                    smallerChildIndex = getRightChildIndex(index);

                if (items[index] < items[smallerChildIndex])
                    break;
                else
                    swap(index, smallerChildIndex);

                index = smallerChildIndex;
            }
        }

        public void print()
        {
            foreach (int item in items)
                Console.Write(item + " ");
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
