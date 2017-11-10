using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binaryTreeBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree tree = new BinaryTree();
            tree.insert(9);
            tree.insert(7);
            tree.insert(11);
            tree.insert(5);
            tree.insert(8);
            tree.insert(12);
            tree.insert(10);

            tree.print();
        }
    }

    class Node
    {
        public int data;
        public Node left;
        public Node right;

        public Node(int value)
        {
            this.data = value;
            left = null; right = null;
        }

        internal void insert(Node top, int value)
        {
            if(value < top.data)
            {
                if (top.left == null)
                    top.left = new Node(value);
                else
                    top.left.insert(top.left, value);
            }
            else
            {
                if (top.right == null)
                    top.right = new Node(value);
                else
                    top.right.insert(top.right, value);
            }
        }

        internal bool contains(Node top, int value)
        {
            if (top == null)
                return false;
            else
            {
                if(value==top.data)
                    return true;
                else if(value<top.data)
                {
                    if (top.left == null)
                        return false;
                    else
                        return top.left.contains(top.left, value);
                }
                else
                {
                    if (top.right == null)
                        return false;
                    else
                        return top.right.contains(top.right, value);
                }
            }
        }

        internal void print(Node top)
        {
            if(top.left!=null)
            top.left.print(top.left);

            Console.Write(top.data + " ");

            if(top.right!=null)
            top.right.print(top.right);
        }
    }

    class BinaryTree
    {
        public Node top;
        int size = 0;

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

        public bool isEmpty()
        {
            return top == null;
        }

        public void insert(int value)
        {
            if (isEmpty())
                top = new Node(value);
            else
                top.insert(top, value);

            size++;
        }

        public bool contains(int value)
        {
            if (top == null)
                return false;
            else return top.contains(top, value);
        }

        public void print()
        {
            if(!isEmpty())
                top.print(top);
            Console.WriteLine();
            Console.WriteLine("Size = " + Size);
        }
    }
}
