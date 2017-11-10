using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BST_Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            binTree tree = new binTree();
            tree.Add(25);
            tree.Add(18);
            tree.Add(29);
            tree.Add(30);
            tree.Add(19);
            tree.Add(12);
            tree.Add(20);

            tree.Print();

            bool exists = tree.Exists(25);

            Console.WriteLine();
            Console.WriteLine(exists ? "Exists" : "Does not exist");

            
        }
    }

    class binTree
    {
        public Node root;

        public void Add(int data)
        {
            if (root == null)
                root = new Node(data);
            else
                root.Add(root, data);
        }

        public bool Exists(int data)
        {
            if (root == null)
                return false;
            else
                return root.exists(root, data);
        }

        public void Print()
        {
            if (root == null)
                return;
            else
                root.print(root);
        }
    }

    class Node
    {
        public Node left, right;
        public int data;

        public Node(int data)
        {
            this.data = data;
            left = null; right = null;
        }

        internal void Add(Node root, int data)
        {
            if (root == null)
                return;
            else
            {
                if (data < root.data)
                {
                    if (root.left != null)
                        root.left.Add(root.left, data);
                    else
                        root.left = new Node(data);
                }
                else
                {
                    if (root.right != null)
                        root.right.Add(root.right, data);
                    else
                        root.right = new Node(data);
                }
            }
        }

        internal bool exists(Node root, int data)
        {
            if (root == null)
                return false;
            else
            {
                if (data == root.data)
                    return true;
                else if (data < root.data)
                    if (root.left != null)
                        return root.left.exists(root.left, data);
                    else
                        return false;
                else
                    if (root.right != null)
                        return root.right.exists(root.right, data);
                    else
                        return false;
            }
        }

        internal void print(Node root)
        {
            if (root.left != null)
                root.left.print(root.left);

            Console.Write(root.data + " ");

            if (root.right != null)
                root.right.print(root.right);
        }
    }
}
