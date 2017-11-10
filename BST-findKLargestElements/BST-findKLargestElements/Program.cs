using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BST_findKLargestElements
{
    class Program
    {
        static void Main(string[] args)
        {
            myTree tree = new myTree();
            tree.Add(19);
            tree.Add(7);
            tree.Add(3);
            tree.Add(11);
            tree.Add(2);
            tree.Add(5);
            tree.Add(17);
            tree.Add(13);
            tree.Add(43);
            tree.Add(47);
            tree.Add(53);
            tree.Add(23);
            tree.Add(37);
            tree.Add(41);
            tree.Add(29);
            tree.Add(31);

            int k = 3;
            List<int> kLargestElem = new List<int>();

            findKLargestElements(tree.root, k, ref kLargestElem);

            foreach (int item in kLargestElem)
                Console.Write(item + " ");

            //tree.PrintRevInOrder();
        }

        private static void findKLargestElements(Node root, int k, ref List<int> kLargestElem)
        {
            if(root!=null && kLargestElem.Count < k)
            {
                if (root.right != null)
                    findKLargestElements(root.right, k, ref kLargestElem);

                if (kLargestElem.Count < k)
                {
                    kLargestElem.Add(root.data);

                    if (root.left != null)
                        findKLargestElements(root.left, k, ref kLargestElem);
                }
            }
        }
    }

    class Node
    {
        public Node left, right;
        public int data;

        public Node(int data)
        {
            this.data = data;
        }

        internal void add(Node root, int data)
        {
            if (root != null)
            {
                if (data < root.data)
                {
                    if (root.left != null)
                        root.left.add(root.left, data);
                    else
                        root.left = new Node(data);
                }
                else
                {
                    if (root.right != null)
                        root.right.add(root.right, data);
                    else
                        root.right = new Node(data);
                }
            }
        }

        internal bool exists(Node root, int data)
        {
            if (root != null)
            {
                if (data == root.data)
                    return true;
                else if (data < root.data)
                {
                    if (root.left != null)
                        return root.left.exists(root.left, data);
                    else return false;
                }
                else
                {
                    if (root.right != null)
                        return root.right.exists(root.right, data);
                    else return false;
                }
            }
            else
                return false;
        }

        internal void printInOrder(Node root)
        {
            if(root!=null)
            {
                if (root.left != null)
                    root.left.printInOrder(root.left);

                Console.Write(root.data + " ");

                if (root.right != null)
                    root.right.printInOrder(root.right);
            }
        }

        internal void printRevInOrder(Node root)
        {
            if(root!=null)
            {
                if (root.right != null)
                    root.right.printRevInOrder(root.right);

                Console.Write(root.data + " ");

                if (root.left != null)
                    root.left.printRevInOrder(root.left);
            }
        }
    }

    class myTree
    {
        public Node root;

        public bool isEmpty()
        {
            return root == null;
        }

        public void Add(int data)
        {
            if (root == null)
                root = new Node(data);
            else
                root.add(root, data);
        }

        public bool Exists(int data)
        {
            if (root == null)
                return false;
            else
                return root.exists(root, data);
        }

        public void PrintInOrder()
        {
            if (root != null)
                root.printInOrder(root);
        }

        internal void PrintRevInOrder()
        {
            if (root != null)
                root.printRevInOrder(root);
        }
    }
}
