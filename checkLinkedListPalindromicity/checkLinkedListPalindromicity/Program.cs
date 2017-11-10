using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checkLinkedListPalindromicity
{
    class Program
    {
        static void Main(string[] args)
        {
            myList list = new myList();
            list.append(1);
            list.append(2);
            list.append(5);
            list.append(0);
            list.append(5);
            list.append(2);
            list.append(1);

            bool palindrome = checkListPalindromicity(list);

            if (palindrome)
                Console.WriteLine("Is palindrome");
            else
                Console.WriteLine("Is not palindrome");
        }

        private static bool checkListPalindromicity(myList list)
        {
            Node slow = list.head, fast = list.head;

            while(fast!=null && fast.next!=null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }

            Node firstHalfHead = list.head;
            Node reversedSublistHead = reverseSublist(slow);

            while (reversedSublistHead != null && firstHalfHead != null)
            {
                if (reversedSublistHead.data != firstHalfHead.data)
                    return false;

                reversedSublistHead = reversedSublistHead.next;
                firstHalfHead = firstHalfHead.next;
            }

            return true;
        }

        private static Node reverseSublist(Node slow)
        {
            //This method identifies the second sublist, reverses it and
            //compares it with the first sublist

            Node prev = null;
            Node current = slow;
            Node next = null;

            while(current!=null)
            {
                next = current.next;
                current.next = prev;
                prev = current;
                current = next;
            }

            slow = prev;
            return slow;
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
