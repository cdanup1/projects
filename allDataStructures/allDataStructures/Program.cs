using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace allDataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            maxHeap maxHeap = new maxHeap();
            maxHeap.Add(35);
            maxHeap.Add(26);
            maxHeap.Add(44);
            maxHeap.Add(30);
            maxHeap.Add(27);
            maxHeap.Add(20);
            maxHeap.Add(40);
            maxHeap.Add(41);
            maxHeap.Add(38);
            maxHeap.Add(36);
            maxHeap.Add(31);
            maxHeap.Add(37);
            maxHeap.Add(39);
            maxHeap.Add(42);
            maxHeap.Add(46);

            maxHeap.Print();
        }
    }

    class Node
    {
        public Node next, left, right;
        public int data;

        public Node(int value)
        {
            data = value;
        }

        internal void addToBST(Node root, int value)
        {
            if(root!=null)
            {
                if (value < root.data)
                    if (root.left != null)
                        root.left.addToBST(root.left, value);
                    else
                        root.left = new Node(value);
                else
                    if (root.right != null)
                        root.right.addToBST(root.right, value);
                    else
                        root.right = new Node(value);
            }
        }

        internal bool containsInBST(Node root, int value)
        {
            if (root != null)
            {
                if (value == root.data)
                    return true;
                else if (value < root.data)
                    if (root.left != null)
                        return root.left.containsInBST(root.left, value);
                    else
                        return false;
                else
                    if (root.right != null)
                        return root.right.containsInBST(root.right, value);
                    else
                        return false;
            }
            else
                return false;
        }

        internal void printInOrder(Node root)
        {
            if (root.left != null)
                root.left.printInOrder(root.left);

            Console.Write(root.data + " ");

            if (root.right != null)
                root.right.printInOrder(root.right);
        }

        internal Node removeValueBST(Node root, int value)
        {
            if (root != null)
            {
                if (value < root.data)
                    root.left = removeValueBST(root.left, value);
                else if (value > root.data)
                    root.right = removeValueBST(root.right, value);
                else //this is the node to be deleted
                {
                    if (root.left == null && root.right == null)
                        root = null;
                    else if (root.right == null)
                        root = root.left;
                    else if (root.left == null)
                        root = root.right;
                    else
                    {
                        Node min = getMinNode(root.right);
                        root.data = min.data;
                        root.right = removeValueBST(root.right, min.data);
                    }
                }
            }

            return root;
        }

        private Node getMinNode(Node node)
        {
            Node temp = node;

            while (temp.left != null)
                temp = temp.left;

            return temp;
        }
    }

    class myList
    {
        public Node head;

        public void Add(int value)
        {
            if (head == null)
                head = new Node(value);
            else
            {
                Node temp = head;
                while (temp.next != null)
                    temp = temp.next;

                temp.next = new Node(value);
            }
        }

        public bool isEmpty()
        {
            return head == null;
        }

        public bool Contains(int value)
        {
            if (head == null)
                return false;
            else
            {
                Node temp = head;
                while (temp != null)
                {
                    if (temp.data == value)
                        return true;

                    temp = temp.next;
                }
            }

            return false;
        }

        public void Remove(int value)
        {
            if(Contains(value))
            {
                if (head.data == value)
                {
                    head = head.next;
                    return;
                }

                Node current = head.next;
                Node prev = head;

                while(current!=null)
                {
                    if(current.data == value)
                    {
                        prev.next = current.next;
                        break;
                    }

                    prev = current;
                    current = current.next;
                }
            }
        }

        public void Print()
        {
            Node temp = head;

            while(temp!=null)
            {
                Console.Write(temp.data + " ");
                temp = temp.next;
            }

            Console.WriteLine();
        }
    }

    class myStack
    {
        public Node top;

        public void Push(int value)
        {
            if (top == null)
                top = new Node(value);
            else
            {
                Node temp = new Node(value);
                temp.next = top;
                top = temp;
            }
        }

        public Node Pop()
        {
            if (top == null)
                return null;
            else
            {
                Node temp = top;
                top = top.next;
                return temp;
            }
        }

        public bool Contains(int value)
        {
            Node temp = top;
            while(temp!=null)
            {
                if (temp.data == value)
                    return true;

                temp = temp.next;
            }

            return false;
        }

        public void Print()
        {
            Node temp = top;
            
            while(temp != null)
            {
                Console.Write(temp.data + " ");
                temp = temp.next;
            }

            Console.WriteLine();
        }
    }

    class myQueue
    {
        public Node head, tail;

        public void Enqueue(int value)
        {
            if(head == null) //There is no node in the queue
            {
                head = new Node(value);
                tail = head;
            }
            else
            {
                Node temp = new Node(value);
                tail.next = temp;
                tail = temp;
            }
        }

        public Node Dequeue()
        {
            if (head == null)
                return null;
            else
            {
                Node temp = head;

                if (head == tail) //Only 1 node in the queue
                    head = tail = null;
                else if (head.next == tail) //2 nodes in the queue
                    head = tail;
                else
                    head = head.next;

                return temp;
            }
        }

        public bool Contains(int value)
        {
            Node temp = head;
            
            while(temp!=null)
            {
                if (temp.data == value)
                    return true;

                temp = temp.next;
            }

            return false;
        }

        public void Print()
        {
            Node temp = head;

            while(temp!=null)
            {
                Console.Write(temp.data + " ");
                temp = temp.next;
            }

            Console.WriteLine();
        }
    }

    class myBST
    {
        public Node root;

        public void Add(int value)
        {
            if (root == null)
                root = new Node(value);
            else
                root.addToBST(root, value);
        }

        public bool Contains(int value)
        {
            if (root != null)
                return root.containsInBST(root, value);
            else
                return false;
        }

        public void PrintInOrder()
        {
            if (root == null)
                return;
            else
                root.printInOrder(root);

            Console.WriteLine();
        }

        public void RemoveValue(int value)
        {
            if (Contains(value))
                root.removeValueBST(root, value);
        }
    }

    class maxHeap
    {
        int capacity = 10;
        int size = 0;
        public int[] arr;

        public maxHeap()
        {
            arr = new int[capacity];
        }

        public int getLeftChildIdx(int parentIdx) { return 2 * parentIdx + 1; }
        public int getRightChildIdx(int parentIdx) { return 2 * parentIdx + 2; }
        public int getParentIdx(int childIdx) { return (childIdx - 1) / 2; }

        public int getLeftChild(int parentIdx) { return arr[getLeftChildIdx(parentIdx)]; }
        public int getRightChild(int parentIdx) { return arr[getRightChildIdx(parentIdx)]; }
        public int getParent(int childIdx) { return arr[getParentIdx(childIdx)]; }

        public bool hasLeftChild(int parentIdx) { return getLeftChildIdx(parentIdx) < capacity; }
        public bool hasRightChild(int parentIdx) { return getRightChildIdx(parentIdx) < capacity; }
        public bool hasParent(int childIdx) { return getParentIdx(childIdx) >= 0; }

        public void Add(int value)
        {
            ensureCapacity();

            arr[size] = value;
            size++;
            heapifyUp();
        }

        public int Remove()
        {
            int val = arr[0];



            return val;

        }

        private void heapifyUp()
        {
            int childIdx = size - 1;
            int value = arr[childIdx];

            while (hasParent(childIdx) && (value > getParent(childIdx)))
            {
                swap(arr, childIdx, getParentIdx(childIdx));
                childIdx = getParentIdx(childIdx);
                value = arr[childIdx];
            }
        }

        private void swap(int[] arr, int idx1, int idx2)
        {
            int temp = arr[idx1];
            arr[idx1] = arr[idx2];
            arr[idx2] = temp;
        }

        private void ensureCapacity()
        {
            if(size == capacity)
            {
                Array.Resize(ref arr, capacity * 2);
                capacity *= 2;
            }
        }

        public void Print()
        {
            for (int i = 0; i < size; i++)
                Console.Write(arr[i] + " ");

            Console.WriteLine();
        }
    }
}
