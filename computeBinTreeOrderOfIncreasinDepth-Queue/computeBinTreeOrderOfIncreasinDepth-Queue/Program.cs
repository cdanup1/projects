using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace computeBinTreeOrderOfIncreasinDepth_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            myQueue queue = new myQueue();
            
        }
    }

    class myQueue
    {
        Node head;
        Node tail;

        public int maxValue;
        public int size;

        public int MaxValue //MaxValue property
        {
            get
            {
                return this.maxValue;
            }

            set
            {
                this.maxValue = value;
            }
        }

        public int Size //Size
        {
            get
            {
                return this.size;
            }
            set
            {
                this.size = value;
            }
        }

        public bool isEmpty()
        {
            return head == null;
        }

        public void enqueue(int data)
        {
            Node temp = new Node(data);

            if(head==null)
            {
                head = temp;
                tail = temp;
                size = 1;
                maxValue = data;
            }
            else
            {
                tail.next = temp;
                tail = temp;
                size++;

                if (data > maxValue)
                    maxValue = data;
            }
        }

        public int dequeue()
        {
            if(size==1)
            {
                head = null;
                size--;
                maxValue = int.MinValue;
                return maxValue;
            }
            else if (head != null)
            {
                int data = head.data;
                head = head.next;
                size--;

                //Use O(n) TC to re-calculate maxValue
                Node temp = head;
                int maxVal = head.data;
                while(temp!=null)
                {
                    int tempVal = temp.data;
                    if (tempVal > maxVal)
                        maxVal = tempVal;

                    temp = temp.next;
                }
                maxValue = maxVal;

                return data;
            }
            else
                return int.MinValue;
        }

        public int peek()
        {
            if (head != null)
                return head.data;
            else
                return int.MinValue;
        }

        public void print()
        {
            Node temp = head;
            while(temp!=null)
            {
                Console.Write(temp.data + " ");
                temp = temp.next;
            }

            Console.WriteLine();
            Console.WriteLine("Size = " + size + " | MaxValue = " + maxValue);
        }
    }

    class Node
    {
        public int data;
        public Node next;

        public Node(int data)
        {
            this.data = data;
        }
    }
}
