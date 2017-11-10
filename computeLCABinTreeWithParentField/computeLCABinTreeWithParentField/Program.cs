using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace computeLCABinTreeWithParentField
{
    class Program
    {
        static void Main(string[] args)
        {
            binaryTree tree = new binaryTree();
            tree.add(45);
            tree.add(22);
            tree.add(21);
            tree.add(26);
            tree.add(34);
            tree.add(76);
            tree.add(55);

            Node first = tree.top.left.left;
            Node second = tree.top.left.right.right;

            Node LCA = computeLCABinTree(tree.top, first, second);
            Console.WriteLine("LCA node = " + LCA.data);

        }

        private static Node computeLCABinTree(Node top, Node first, Node second)
        {
            int firstHeight = getHeight(first), secondHeight = getHeight(second);

            if (firstHeight > secondHeight)
            {
                while (firstHeight > secondHeight)
                {
                    first = first.parent;
                    firstHeight--;
                }
            }
            else
            {
                while (secondHeight > firstHeight)
                {
                    second = second.parent;
                    secondHeight--;
                }
            }

            while (first != second)
            {
                first = first.parent;
                second = second.parent;
            }

            return first;
        }

        private static int getHeight(Node node)
        {
            int height = 0;
            Node temp = node;

            while(temp.parent!=null)
            {
                height++;
                temp = temp.parent;//traverse up the tree
            }

            return height;
        }
    }

    class binaryTree
    {
        public Node top;

        public void add(int value)
        {
            if (top == null)
                top = new Node(value);
            else
                top.add(top, value);
        }

        public bool contains(int value)
        {
            return top.contains(top, value);
        }

        public void printInOrder()
        {
            top.printInOrder(top);
        }
    }

    class Node
    {
        public int data;
        public Node left;
        public Node right;
        public Node parent;

        public Node(int value)
        {
            this.data = value;
            this.left = null;
            this.right = null;
            this.parent = null;
        }

        internal void add(Node top, int value)
        {
            if (top == null)
                top = new Node(value);
            else
            {
                if (value < top.data)
                    if (top.left == null)
                    {
                        top.left = new Node(value);
                        top.left.parent = top;
                    }
                    else
                        top.left.add(top.left, value);
                else
                    if (top.right == null)
                    {
                        top.right = new Node(value);
                        top.right.parent = top;
                    }
                    else
                        top.right.add(top.right, value);
            }
        }

        internal bool contains(Node top, int value)
        {
            if (top.data == value)
                return true;
            else if (value < top.data)
                return contains(top.left, value);
            else
                return contains(top.right, value);
        }

        internal void printInOrder(Node top)
        {
            if (top == null)
                return;
            else
            {
                if (top.left != null)
                    top.left.printInOrder(top.left);

                Console.Write(top.data + " ");

                if (top.right != null)
                    top.left.printInOrder(top.right);
            }
        }
    }
}
