using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIBinaryTree.BT
{
    public class BinaryTree
    {
        private static Node root;

        private static int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
        private static Node newNode(int item)
        {
            Node temp = new Node();
            temp.key = item;
            temp.left = null;
            temp.right = null;
            temp.parent = null;
            return temp;
        }

        private static Node insert(Node node, int key)
        {
            if (node == null) return newNode(key);

            if (key < node.key)
            {
                Node lchild = insert(node.left, key);
                node.left = lchild;

                lchild.parent = node;
            }
            else if (key > node.key)
            {
                Node rchild = insert(node.right, key);
                node.right = rchild;

                rchild.parent = node;
            }

            return node;
        }

        public bool CrearBinaryTree()
        {

            root = insert(root, 30);

            for (int i = 0; i < 10; i++)
            {
                int NuevoNode = RandomNumber(1, 100);
                insert(root, NuevoNode);
            }
         
            return true;
        }

        public int BuscarPadre(int key)
        {
            return BuscarPadres(root, key, 0) ?? 0;
        }

        public int BuscarPadre(int key1, int key2)
        {
            return BuscarPadres(root, key1, key2) ?? 0;
        }

        private static int? BuscarPadres(Node root, int key1, int key2)
        {

            Node n1 = buscarNode(root, key1);
            Node n2 = buscarNode(root, key2);

            if (n1 != null && n2 != null)
            {
                List<int> padresNode1 = new List<int>();
                buscarPadre(n1, ref padresNode1);


                List<int> padresNode2 = new List<int>();
                buscarPadre(n2, ref padresNode2);

                var firstNotSecond = padresNode1.Intersect(padresNode2);

                if (firstNotSecond.Any())
                    return firstNotSecond.FirstOrDefault();
                else
                    return 0;
            }
            else
            {
                if (n1 != null)
                {
                    return n1?.parent?.key;
                }
                if (n2 != null)
                {
                    return n2?.parent?.key;

                }
            }

            return 0;
        }

        private static Node buscarNode(Node node, int key)
        {
            if (node == null)
                return null;
            else if (key.CompareTo(node.key) < 0)
                return buscarNode(node.left, key);
            else if (key.CompareTo(node.key) > 0)
                return buscarNode(node.right, key);

            return node;
        }

        private static void buscarPadre(Node node, ref List<int> padres)
        {
            if (node.parent != null)
            {
                padres.Add(node.parent.key);
                buscarPadre(node.parent, ref padres);
            }
        }
    }
}
