using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace computeExteriorOfBinTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Node top = new Node(314);
            top.left = new Node(6);
            top.left.left = new Node(271);
            top.left.left.left = new Node(28);
            top.left.left.right = new Node(0);
            top.left.right = new Node(561);
            top.left.right.right = new Node(3);
            top.left.right.right.left = new Node(17);
            top.right = new Node(6);
            top.right.right = new Node(271);
            top.right.right.right = new Node(28);
            top.right.left = new Node(2);
            top.right.left.right = new Node(1);
            top.right.left.right.left = new Node(401);
            top.right.left.right.left.right = new Node(641);
            top.right.left.right.right = new Node(257);

            List<Node> exterior = new List<Node>();

            computeExterior(top, exterior);

            foreach (Node node in exterior)
                Console.Write(node.data + " ");
        }

        private static void computeExterior(Node top, List<Node> exterior)
        {
            exterior.Add(top); // Add root
            exterior.AddRange(computeLeftSubtreeExterior(top.left, true));
            exterior.AddRange(computeRightSubtreeExterior(top.right, true));
        }

        private static IEnumerable<Node> computeLeftSubtreeExterior(Node leftSubtree, bool isBoundary)
        {
            List<Node> leftExterior = new List<Node>();

            if (leftSubtree != null)
            {
                if (isBoundary || isLeaf(leftSubtree))
                    leftExterior.Add(leftSubtree);

                leftExterior.AddRange(computeLeftSubtreeExterior(leftSubtree.left, isBoundary));
                leftExterior.AddRange(computeLeftSubtreeExterior(leftSubtree.right, isBoundary && leftSubtree.left == null));
            }

            return leftExterior;
        }

        private static IEnumerable<Node> computeRightSubtreeExterior(Node rightSubtree, bool isBoundary)
        {
            List<Node> rightExterior = new List<Node>();

            if(rightSubtree!=null)
            {
                if (isBoundary || isLeaf(rightSubtree))
                    rightExterior.Add(rightSubtree);

                rightExterior.AddRange(computeRightSubtreeExterior(rightSubtree.right, isBoundary));
                rightExterior.AddRange(computeRightSubtreeExterior(rightSubtree.left, isBoundary && rightSubtree.right == null));
            }

            return rightExterior;
        }

        private static bool isLeaf(Node leftSubtree)
        {
            return leftSubtree.left == null && leftSubtree.right == null;
        }
    }

    class Node
    {
        public Node left;
        public Node right;
        public Node parent;

        public int data;

        public Node(int value)
        {
            data = value;
        }

        public void add(Node top, int data)
        {
            if (top != null)
            {
                if (data < top.data)
                {
                    if (top.left == null)
                    {
                        top.left = new Node(data);
                        top.left.parent = top;
                    }
                    else
                        top.left.add(top.left, data);
                }
                else
                {
                    if (top.right == null)
                    {
                        top.right = new Node(data);
                        top.right.parent = top;
                    }
                    else
                        top.right.add(top.right, data);
                }
            }
        }

        public bool contains(Node top, int data)
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
            if (top.left != null)
                top.left.printInOrder(top.left);

            Console.Write(top.data + " ");

            if (top.right != null)
                top.right.printInOrder(top.right);
        }


        internal void printInOrder(Node top, List<int> inOrder)
        {
            if (top.left != null)
                top.left.printInOrder(top.left, inOrder);

            inOrder.Add(top.data);

            if (top.right != null)
                top.right.printInOrder(top.right, inOrder);
        }

        internal void printPreOrder(Node top)
        {
            if (top != null)
            {
                Console.Write(top.data + " ");

                if (top.left != null)
                    top.left.printPreOrder(top.left);

                if (top.right != null)
                    top.right.printPreOrder(top.right);
            }
        }

        internal void printPreOrder(Node top, List<int> preOrder)
        {
            if (top != null)
            {
                preOrder.Add(top.data);

                if (top.left != null)
                    top.left.printPreOrder(top.left, preOrder);

                if (top.right != null)
                    top.right.printPreOrder(top.right, preOrder);
            }
        }

        internal void printPostOrder(Node top, List<int> postOrder)
        {
            if (top != null)
            {

                if (top.left != null)
                    top.left.printPostOrder(top.left, postOrder);

                if (top.right != null)
                    top.right.printPostOrder(top.right, postOrder);

                postOrder.Add(top.data);
            }
        }

        internal void printPostOrder(Node top)
        {
            if (top != null)
            {
                if (top.left != null)
                    top.left.printPostOrder(top.left);

                if (top.right != null)
                    top.right.printPostOrder(top.right);

                Console.Write(top.data + " ");
            }
        }
    }

    class myBinaryTree
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
            if (top.data == data)
                return true;
            else
                return top.contains(top, data);
        }

        public void printInOrder()
        {
            top.printInOrder(top);
        }

        public List<int> printInOrder(List<int> inOrder)
        {
            top.printInOrder(top, inOrder);

            return inOrder;
        }

        public void printPreOrder()
        {
            top.printPreOrder(top);
        }

        public List<int> printPreOrder(List<int> preOrder)
        {
            top.printPreOrder(top, preOrder);
            return preOrder;
        }


        internal List<int> printPostOrder(List<int> postOrder)
        {
            top.printPostOrder(top, postOrder);
            return postOrder;
        }
    }

}
