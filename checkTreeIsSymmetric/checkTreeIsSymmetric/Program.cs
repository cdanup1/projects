using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checkTreeIsSymmetric
{
    class Program
    {
        static void Main(string[] args)
        {
            binaryTree tree = new binaryTree();
            tree.add(314);
            tree.top.left = new Node(6);
            tree.top.right = new Node(6);
            tree.top.left.right = new Node(2);
            tree.top.right.left = new Node(2);
            tree.top.left.right.right = new Node(3);
            tree.top.right.left.left = new Node(3);

            bool result = checkSymmetricTree(tree.top);

            if (result)
                Console.WriteLine("Tree is symmetric");
            else
                Console.WriteLine("Tree is not symmetric");
        }

        private static bool checkSymmetricTree(Node top)
        {
            return (top == null) || isSymmetric(top.left, top.right);
        }

        private static bool isSymmetric(Node left, Node right)
        {
            if (left != null && right != null)
                if (left.data != right.data)
                    return false;
                else
                {
                    if (!isSymmetric(left.left, right.right) || !isSymmetric(left.right, right.left))
                        return false;
                }

            else //Check for structurally asymmetric tree
                if ((left != null && right == null) || (left == null && right != null))
                    return false;

            return true;
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

        public Node(int value)
        {
            this.data = value;
            this.left = null;
            this.right = null;
        }

        internal void add(Node top, int value)
        {
            if (top == null)
                top = new Node(value);
            else
            {
                if (value < top.data)
                    if (top.left == null)
                        top.left = new Node(value);
                    else
                        top.left.add(top.left, value);
                else
                    if (top.right == null)
                        top.right = new Node(value);
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
