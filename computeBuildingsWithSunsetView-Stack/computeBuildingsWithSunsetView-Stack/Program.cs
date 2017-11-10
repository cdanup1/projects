using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace computeBuildingsWithSunsetView_Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create list of east->west building nodes
            Building start = new Building(0, 6);
            Building head = start;
            start.next = new Building(1, 12);
            start = start.next; //ID-1
            start.next = new Building(2, 11);
            start = start.next; //ID-2
            start.next = new Building(3, 10);
            start = start.next; //ID-3
            start.next = new Building(4, 9);
            start = start.next; //ID-4
            start.next = new Building(5, 8);
            start = start.next; //ID-5
            start.next = new Building(6, 8);
            start = start.next; //ID-6
            start.next = new Building(7, 7);
            start = start.next; //ID-7
            start.next = new Building(8, 6);
            start = start.next; //ID-8

            List<int> buildingIDsWithSunsetView = computeBuildingsWithSunsetView(head);

            foreach(int ID in buildingIDsWithSunsetView)
            {
                Console.Write(ID + " ");
            }
        }

        private static List<int> computeBuildingsWithSunsetView(Building head)
        {
            MyStack stack = new MyStack();
            Building start = head;

            List<int> buildistList = new List<int>();

            stack.push(head.ID, head.height);
            start = head.next;
            while(start!=null)
            {
                while (stack.top!=null && start.height >= stack.top.height)
                    stack.pop();

                stack.push(start.ID, start.height);

                start = start.next;
            }

            while (stack.top != null)
                buildistList.Add(stack.pop());

            return buildistList;
        }
    }


    class MyStack
    {
        public Building top;

        public bool isEmpty()
        {
            return top == null;
        }

        public int peek()
        {
            if (top == null)
                return int.MinValue;
            else
                return top.height;
        }

        public void push(int ID, int height)
        {
            Building temp = new Building(ID, height);

            if (top == null)
            {
                top = temp;
            }
            else
            {
                temp.next = top;
                top = temp;
            }
        }

        public int pop()
        {
            if (top == null)
                return int.MinValue;
            else if (top.next != null)
            {
                int ID = top.ID;
                top = top.next;
                return ID;
            }
            else
            {
                int ID = top.ID;
                top = null;
                return ID;
            }
        }

        public void print()
        {
            Building temp = top;
            while (temp != null)
            {
                Console.Write(temp.height + " ");
                temp = temp.next;
            }
            Console.WriteLine();
        }
    }

    class Building
    {
        public int ID;
        public int height;
        public Building next;

        public Building(int ID, int height)
        {
            this.ID = ID;
            this.height = height;
        }
    }

}
