using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checkTreeIsHeightBalanced
{
    class Program
    {
        static void Main(string[] args)
        {
            binaryTree tree = new binaryTree();
            tree.add(17);
            tree.add(10);
            tree.add(24);
            tree.add(12);
            tree.add(9);
            tree.add(18);
            tree.add(25);

            bool result = checkTreeIsHeightBalanced(tree.top);

            Console.WriteLine();

            if (result)
                Console.WriteLine("Tree is height balanced");
            else
                Console.WriteLine("Tree is not height balanced");
        }

        private static bool checkTreeIsHeightBalanced(Node top)
        {
            int result = isBalanced(top);

            if (result > 0)
                return true;
            else
                return false;
        }

        private static int isBalanced(Node top)
        {
            if (top == null)
                return 0;

            int leftH = isBalanced(top.left);
            if (leftH == -1)
                return -1;

            int rightH = isBalanced(top.right);
            if (rightH == -1)
                return -1;

            if (Math.Abs(leftH - rightH) > 1)
                return -1;

            return 1 + Math.Max(leftH, rightH);
        }
    }

    class binaryTree
    {
        public Node top;

        public void add(int value)
        {
            if(top==null)
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
                if(top.left!=null)
                    top.left.printInOrder(top.left);
                
                Console.Write(top.data + " ");

                if(top.right!=null)
                    top.left.printInOrder(top.right);
            }
        }
    }
}
