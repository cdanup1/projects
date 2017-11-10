using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace computeLowestCommonAncestorBinTree
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

            Node LCA = computeLowestCommonAncestor(tree.top, first, second);

            Console.WriteLine("LCA = " + LCA.data);
        }

        private static Node computeLowestCommonAncestor(Node top, Node first, Node second)
        {
            /*Solution:
             * Check for the case when a sub-tree has the first and the second nodes on
             * two different sides of the tree.  The root of that sub-tree is the LCA.
             */

            Node temp = top;

            while(temp!=null)
            {
                //Check for LCA and check if the two nodes themselves are LCAs
                if ((first.data < temp.data) && (second.data > temp.data)
                    || (first.data == temp.data) || (second.data == temp.data))
                    return temp;

                //Go left
                if (first.data < temp.data && second.data < temp.data)
                    temp = temp.left;
                else //Go right
                    temp = temp.right;
            }

            return temp;
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
