using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addListBasedIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            myList l1 = new myList();
            l1.append(3);
            l1.append(1);
            l1.append(4);

            myList l2 = new myList();
            l2.append(7);
            l2.append(0);
            l2.append(9);
            l2.append(1);
            l2.append(1);
            l2.append(1);

            myList l3 = addListBasedIntegers(l1, l2);
            l3.print();
        }

        private static myList addListBasedIntegers(myList l1, myList l2)
        {
            myList l3 = new myList();
            Node l1Head = l1.head;
            Node l2Head = l2.head;

            int carry = 0, l1Value=0, l2Value=0, l3Value=0;
            while(l1Head!=null || l2Head!=null)
            {
                if (l1Head != null) l1Value = l1Head.data; else l1Value = 0;
                if (l2Head != null) l2Value = l2Head.data; else l2Value = 0;
                l3Value = l1Value + l2Value + carry;
                carry = l3Value / 10;
                l3Value %= 10;

                l3.append(l3Value);

                if (l1Head != null) l1Head = l1Head.next;
                if (l2Head != null) l2Head = l2Head.next;
            }
            if (carry > 0) l3.append(carry);

            return l3;
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

    class myList
    {
        public Node head;
        int size;
        public int Size
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

        public void append(int data)
        {
            Node temp = head;
            if (temp == null)
            {
                size = 0;
                head = new Node(data);
                size++;
                return;
            }

            while (temp.next != null)
                temp = temp.next;

            temp.next = new Node(data);
            size++;
        }

        public void removeFromEnd()
        {
            Node prev = head;
            Node temp = head;

            if (size == 0) return;

            if (temp.next == null) //only head node is present
            {
                head = null;
                size--;
                return;
            }

            while (temp.next != null)
            {
                temp = temp.next;
                if (temp.next == null)
                {
                    prev.next = null;
                    size--;
                    return;
                }
                prev = temp;
            }
        }

        public void print()
        {
            Node temp = head;

            while (temp != null)
            {
                Console.Write(temp.data + " ");
                temp = temp.next;
            }
            Console.Write("\n");
            Console.WriteLine("Size = " + size);
        }
    }
}
