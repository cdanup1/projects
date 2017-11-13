using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace computeTheSuccessorOfANode
{
    class Program
    {
        static void Main(string[] args)
        {
            binaryTree tree = new binaryTree();
            tree.add(31);
            tree.add(15);
            tree.add(45);
            tree.add(12);
            tree.add(20);
            tree.add(18);
            tree.add(40);
            tree.add(42);

            Node findSuccessorOf = tree.top.left.right;

            Node found = findSuccessorOfNode(findSuccessorOf);
            
            /* BRUTE_FORCE solution
             * 
            Node found = new Node(0);
            List<Node> inOrderTraversal = new List<Node>();

            findSuccessorOfNode(tree.top, inOrderTraversal);

            if(inOrderTraversal.IndexOf(findSuccessorOf) > 0)
                if (inOrderTraversal[inOrderTraversal.IndexOf(findSuccessorOf)].data == findSuccessorOf.data)
                    found = inOrderTraversal[inOrderTraversal.IndexOf(findSuccessorOf) + 1];
            */

            Console.WriteLine("Successor = " + found.data);
        }

        private static Node findSuccessorOfNode(Node findSuccessorOf)
        {
            Node iter = findSuccessorOf;

            //Check if a right sun-tree exists
            if(iter.right!=null)
            {
                iter = iter.right;
                //The left-most node in the right-sub tree is the successor
                while(iter.left!=null)
                {
                    iter = iter.left;
                }
            }

            if(iter.right == null)
            {
                while(iter.parent.left!=iter && iter.parent!=null)
                {
                    iter = iter.parent;
                }

                iter = iter.parent;
            }

            return iter;
        }

        /* BRUTE_FORCE Solution
        private static void findSuccessorOfNode(Node top, List<Node> inOrderTraversal)
        {
            findSuccessorOfNodeHelper(top, inOrderTraversal);
        }

        private static void findSuccessorOfNodeHelper(Node top, List<Node> inOrderTraversal)
        {
            if (top != null)
            {
                //Brute force solution -- Traverse recursively inOrder and find the next node
                if (top.left != null)
                    findSuccessorOfNodeHelper(top.left, inOrderTraversal);

                inOrderTraversal.Add(top);

                if (top.right != null)
                    findSuccessorOfNodeHelper(top.right, inOrderTraversal);
            }
        }
         * */
    }

    public class Node
    {
        public Node left;
        public Node right;
        public Node parent;
        public int data;

        public Node(int value)
        {
            this.data = value;
        }


        internal void add(Node top, int data)
        {
            if (top == null)
                top = new Node(data);
            else
            {
                if (data < top.data)
                    if (top.left == null)
                    {
                        top.left = new Node(data);
                        top.left.parent = top;
                    }
                    else
                        top.left.add(top.left, data);
                else
                    if (top.right == null)
                    {
                        top.right = new Node(data);
                        top.right.parent = top;
                    }
                    else
                        top.right.add(top.right, data);
            }
        }

        internal bool contains(Node top, int data)
        {
            if (top == null)
                return false;
            else
            {
                if (top.data == data)
                    return true;
                else if (data < top.data)
                    return top.left.contains(top.left, data);
                else
                    return top.right.contains(top.right, data);
            }
        }

        internal void printInOrder(Node top)
        {
            if (top.left != null)
                top.left.printInOrder(top.left);

            Console.Write(top.data + " ");

            if (top.right != null)
                top.right.printInOrder(top.right);
        }
    }

    public class binaryTree
    {
        public Node top;

        public void add(int data)
        {
            if (top == null)
                top = new Node(data);
            else
            {
                top.add(top, data);
            }
        }

        public bool contains(int data)
        {
            if (top == null)
                return false;
            else
                return top.contains(top, data);
        }

        public void printInOrder()
        {
            top.printInOrder(top);
        }
    }
}
