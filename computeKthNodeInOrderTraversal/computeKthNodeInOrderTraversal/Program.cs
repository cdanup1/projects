using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace computeKthNodeInOrderTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            //Assume additional information is available about how many nodes
            //are present in the sub-tree rooted at that node
            int k = 4;

            binaryTree tree = new binaryTree();
            tree.add(21);
            tree.add(15);
            tree.add(35);
            tree.add(14);
            tree.add(19);
            tree.add(16);
            tree.add(22);

            computeKthNode(tree.top, k);
        }

        private static void computeKthNode(Node top, int k)
        {
            if (k == 0) return;

            int thisNodeNo = 1;

            computeKthNodeHelper(top, ref thisNodeNo, k);
        }

        private static void computeKthNodeHelper(Node top, ref int thisNodeNo, int k)
        {
            //Brute force solution -- Uses O(n) TC and O(h) space complexity
            if(top!=null)
            {
                if (top.left != null)
                    computeKthNodeHelper(top.left, ref thisNodeNo, k);

                if(thisNodeNo==k)
                    Console.WriteLine(top.data + " ");
                thisNodeNo++;

                if (top.right != null)
                    computeKthNodeHelper(top.right, ref thisNodeNo, k);
            }

            //O(h) solution -- Uses information about the number of nodes present in each sub-tree
            //pseudocode
            /* if (k > leftItems + 1) // Node is in the right sub-tree
             *  item is in right subtree
             *  k -= (leftItems + 1) // reduce value of k to facilitate search within in the right subtree
             *  iter = iter.right
             * else if (k == leftItems + 1) // This is the node
             *  return iter
             * else // Node is in left sub-tree itself
             *  iter = iter.left
             */
        }
    }

    public class binaryTree
    {
        public Node top;

        public binaryTree()
        {
            top = null;
        }

        public void add(int data)
        {
            if (top == null)
                top = new Node(data);
            else
                top.add(top, data);
        }

        public bool contains(int data)
        {
            bool result = top.contains(top, data);
            return result;
        }

        public void printInOrder()
        {
            top.printInOrder(top);
        }

    }

    public class Node
    {
        public Node left;
        public Node right;
        public int data;

        public Node(int value)
        {
            this.left = null;
            this.right = null;
            data = value;
        }

        internal void add(Node top, int data)
        {
            if (top == null)
                top = new Node(data);
            else
            {
                if (data < top.data)
                    if (top.left == null)
                        top.left = new Node(data);
                    else
                        top.left.add(top.left, data);
                else
                    if (top.right == null)
                        top.right = new Node(data);
                    else
                        top.right.add(top.right, data);
            }
        }

        internal bool contains(Node top, int data)
        {
            if (top == null)
                return false;

            if (top.data == data)
                return true;
            else
            {
                if (data < top.data)
                    return top.left.contains(top.left, data);
                else
                    return top.right.contains(top.right, data);
            }
        }

        internal void printInOrder(Node top)
        {
            if (top != null)
            {
                if (top.left != null)
                    top.left.printInOrder(top.left);

                Console.Write(top.data + " ");

                if (top.right != null)
                    top.right.printInOrder(top.right);
            }
        }
    }
}
