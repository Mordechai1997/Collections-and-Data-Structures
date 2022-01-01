using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractCollections
{
    class BinarySearchTree
    {
        private Node<int> _root;

        public Node<int> Root { get => _root; set => _root = value; }

        public enum TraversalOrder
        {
            PreOrder,
            InOrder,
            PostOrder
        }
        public BinarySearchTree()
        {
            _root = null;
        }
        public void TreeClear()
        {
            _root = null;
        }
        public bool TreeAdd(int item)
        {
            if (_root == null)
            {
                _root = new Node<int>(item);
                return true;
            }
            Node<int> temp = LocationNode(_root, new Node<int>(item));

            if (temp.Value > item)
            {
                temp.Left = new Node<int>(item, temp);
            }
            else
            {
                if (temp.Value == item)
                    return false;
                temp.Right = new Node<int>(item, temp);
            }
            return true;

        }

        private Node<int> LocationNode(Node<int> root, Node<int> newNode)
        {
            if (newNode.Value < root.Value && root.Left != null)
                return LocationNode(root.Left, newNode);
            if (newNode.Value > root.Value && root.Right != null)
                return LocationNode(root.Right, newNode);
            return root;
        }
        public int TreeMin()
        {
            Node<int> temp = _root;
            while (temp.Left != null)
            {
                temp = temp.Left;
            }
            return temp.Value;
        }
        private int TreeMaxRec(Node<int> root, int max)
        {
            if (root == null)
                return max;
            if (root.Value > max)
                max = root.Value;
            return Math.Max(TreeMaxRec(root.Right,max) , TreeMaxRec(root.Left,max)) ;
        }
        public int TreeMax()

        {
            return TreeMaxRec(_root, 0);
        }
        public bool TreeIstFound(int item)
        {
            return TreeIsDatatFound(_root, item);
        }
        private int SubtreeNodesSumRec(Node<int> root)
        {
            if (root == null)
                return 0;

            return SubtreeNodesSumRec(root.Right) + SubtreeNodesSumRec(root.Left) + root.Value;
        }
        public int SubtreeNodesSum()
        {
            return SubtreeNodesSumRec(_root);
        }


        private int SubtreeNumOfNodesRec(Node<int> root)
        {
            if (root == null)
                return 0;

            return SubtreeNumOfNodesRec(root.Right) + SubtreeNumOfNodesRec(root.Left) + 1;
        }
        public int SubtreeNumOfNodes()
        {


            return SubtreeNumOfNodesRec(_root);
        }
        private bool TreeIsDatatFound(Node<int> root, int item)
        {
            if (item < root.Value && root.Left != null)
                return TreeIsDatatFound(root.Left, item);
            if (item > root.Value && root.Right != null)
                return TreeIsDatatFound(root.Right, item);
            if (item == root.Value)
                return true;
            return false;
        }
        //TraversalOrder traversalMode
        public void PrintTree(TraversalOrder printTree)
        {

            if (printTree == TraversalOrder.InOrder)
            {
                InOrder(_root);
            }
            else if (printTree == TraversalOrder.PreOrder)
            {
                PreOrder(_root);
            }
            else if (printTree == TraversalOrder.PostOrder)
            {
                PostOrder(_root);
            }
        }
        private void InOrder(Node<int> root)
        {
            if (root == null)
                return;
            InOrder(root.Left);
            Console.Write(root.Value + " ");
            InOrder(root.Right);


        }
        private void PreOrder(Node<int> root)
        {
            if (root == null)
                return;
            Console.Write(root.Value + " ");
            PreOrder(root.Left);
            PreOrder(root.Right);


        }
        private void PostOrder(Node<int> root)
        {
            if (root == null)
                return;
            PostOrder(root.Left);
            PostOrder(root.Right);
            Console.Write(root.Value + " ");


        }

        private bool IsAnyEvenRec(Node<int> currentNode)
        { 

            if (currentNode == null)
            {
                return false;

            }
            if (currentNode.Value % 2 == 0)
            {
                return true;
            }
            return IsAnyEvenRec(currentNode.Right) || IsAnyEvenRec(currentNode.Left);
        }
        public bool IsAnyEven()
        {
            return IsAnyEvenRec(this._root);
        }
        public bool AreAllAnyEven()
        {
            if (_root == null)
            {
                return false;
            }
            return AreAllAnyEvenRec(_root);
        }
        public bool AreAllAnyEvenRec(Node<int> currentNode)
        {

            if (currentNode == null)
            {
                return true;
            }
            if (currentNode.Value % 2 != 0)
            {
                return false;
            }
            return AreAllAnyEvenRec(currentNode.Right) && AreAllAnyEvenRec(currentNode.Left);
        }
        private bool IsFullTreeRec(Node<int> currentNode)
        {
            if(currentNode==null)
            {
                return true;
            }
            if(currentNode.Right!= null && currentNode.Left==null )
            {
                return false;
            }
            if (currentNode.Right == null && currentNode.Left != null)
            {
                return false;
            }
            return IsFullTreeRec(currentNode.Right) && IsFullTreeRec(currentNode.Left);
        }
        public static bool AreSimlarTree(Node<int> currentNode1, Node<int> currentNode2)
        {
            if (currentNode1 == null && currentNode2 == null)
            {
                return true;
            }
            if (currentNode1.Right != null && currentNode2.Right == null || currentNode1.Right == null && currentNode2.Right != null)
            {
                return false;
            }
            if (currentNode1.Left != null && currentNode2.Left == null || currentNode1.Left == null && currentNode2.Left != null)
            {
                return false;
            }
            return AreSimlarTree(currentNode1.Right, currentNode2.Right) && AreSimlarTree(currentNode1.Left, currentNode2.Left);
        }
        public bool IsFullTree()
        {
            return IsFullTreeRec(_root);
        }

    }
    public class Node<T>
    {
        Node<T> left, right, father;
        T value;
        public Node(T value)
        {
            this.value = value;
            left = right = father = null;
        }
        public Node(T value, Node<T> father)
        {
            this.father = father;
            this.value = value;
            left = right = null;

        }
        public Node(T value, Node<T> father, Node<T> left, Node<T> right)
        {
            this.left = left;
            this.right = right;
            this.father = father;
            this.value = value;
        }

        public Node<T> Left { get => left; set => left = value; }
        public Node<T> Right { get => right; set => right = value; }
        public Node<T> Father { get => father; set => father = value; }
        public T Value { get => value; set => this.value = value; }
    }
}
