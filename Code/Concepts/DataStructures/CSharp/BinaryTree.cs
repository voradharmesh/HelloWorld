using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.CSharp
{
    public class DRVBinaryTree<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        private BinaryTreeNode<T> _head;
        private int _count;

        #region ADD

        public void Add(T value)
        {
            if (_head==null) 
                _head = new BinaryTreeNode<T>(value);
            else
                Add(_head, value);
            _count++;
        }

        private void Add(BinaryTreeNode<T> node, T value)
        {
            if (value.CompareTo(node.Value) < 0)
            {
                if (node.Left == null)
                    node.Left = new BinaryTreeNode<T>(value);
                else
                    Add(node.Left,value);
            }
            else
            {
                if (node.Right == null)
                    node.Right = new BinaryTreeNode<T>(value);
                else
                    Add(node.Right, value);
            }   
        }
        #endregion ADD

        public bool Contains(T value)
        {
            BinaryTreeNode<T> parent;
            return FindWithParent(value, out parent) != null;
        }

        private BinaryTreeNode<T> FindWithParent(T value, out BinaryTreeNode<T> parent)
        {
            BinaryTreeNode<T> current = _head;
            parent = null;
            while (current != null)
            {
                var result = current.CompareTo(value);
                if (result > 0)
                {
                    parent = current;
                    current = current.Left;
                }
                else if (result < 0)
                {
                    parent = current;
                    current = current.Right;
                }
                else
                {
                    break;
                }
            }
            return current;
        }

        #region REMOVE

        public bool Remove(T value)
        {
            BinaryTreeNode<T> current, parent;
            current = FindWithParent(value, out parent);
            if (current == null) return false;
            _count--;
            //case 1: If current has no right child, then current's left replaces current.
            if (current.Right == null)
            {
                if (parent == null) 
                    _head = current.Left;
                else
                {
                    var result = parent.CompareTo(current.Value);
                    if (result > 0)
                        parent.Left = current.Left;
                    else if (result < 0)
                        parent.Right = current.Left;
                }
            }
            //case 2:if current's right child has no left child, 
            //then current's right child replaces current.
            else if (current.Right.Left == null)
            {
                current.Right.Left = current.Left;
                if (parent == null) 
                    _head = current.Right;
                else
                {
                    var result = parent.CompareTo(current.Value);
                    if (result > 0)
                        parent.Left = current.Right;
                    else
                        parent.Right = current.Right;
                }
            }
            //case 3:if current's right child has a left child, replace current 
            //with current's right child's left-most child
            else
            {
                var leftmost = current.Right.Left;
                var leftmostParent = current.Right;
                while (leftmost.Left != null)
                {
                    leftmostParent = leftmost;
                    leftmost = leftmost.Left;
                }
                //parent's left subtree becomes the leftmost's right subtree 
                leftmostParent.Left = leftmost.Right;
                //assign leftmost's left and right to current's left and right children
                leftmost.Left = current.Left;
                leftmost.Right = current.Right;
                if (parent == null)
                    _head = leftmost;
                else
                {
                    var result = parent.CompareTo(current.Value);
                    if (result > 0)
                        parent.Left = leftmost;
                    else
                        parent.Right = leftmost; 
                }
            }
            return true;
        }
        #endregion REMOVE

        #region PRE-ORDER TRAVERSAL

        public void PreOrderTraversal(Action<T> action)
        {
            PreOrderTraversal(action, _head);
        }

        private void PreOrderTraversal(Action<T> action, BinaryTreeNode<T> node)
        {
            if (node == null) return;
            action(node.Value);
            PreOrderTraversal(action, node.Left);
            PreOrderTraversal(action, node.Right);
        }

        #endregion PRE-ORDER TRAVERSAL

        #region POST-ORDER TRAVERSAL

        public void PostOrderTraversal(Action<T> action)
        {
            PostOrderTraversal(action, _head);
        }
        private void PostOrderTraversal(Action<T> action, BinaryTreeNode<T> node)
        {
            if (node == null) return;
            PostOrderTraversal(action, node.Left);
            PostOrderTraversal(action, node.Right);
            action(node.Value);
        }

        #endregion POST-ORDER TRAVERSAL

        #region IN-ORDER TRAVERSAL

        public void InOrderTraversal(Action<T> action)
        {
            InOrderTraversal(action, _head);
        }
        private void InOrderTraversal(Action<T> action, BinaryTreeNode<T> node)
        {
            if (node == null) return;
            InOrderTraversal(action, node.Left);
            action(node.Value);
            InOrderTraversal(action, node.Right);
         }

        public IEnumerator<T> InOrderTraversal()
        {
            if (_head == null) yield break;
            var stack = new Stack<BinaryTreeNode<T>>();
            var current = _head;
            var goLeftNext = true;
            stack.Push(current);
            while (stack.Count > 0)
            {
                if (goLeftNext)
                {
                    while (current.Left != null)
                    {
                        stack.Push(current);
                        current = current.Left;
                    }
                }
                yield return current.Value;

                if (current.Right != null)
                {
                    current = current.Right;
                    goLeftNext = true;
                }
                else
                {
                    current = stack.Pop();
                    goLeftNext = false;
                }
            }
        }
        
        #endregion IN-ORDER TRAVERSAL

        public IEnumerator<T> GetEnumerator()
        {
            return InOrderTraversal();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Clear()
        {
            _head = null;
            _count = 0;
        }

        public int Count { get { return _count; } }
    }


    class BinaryTreeNode<TNode> : IComparable<TNode> where TNode : IComparable<TNode>
    {
        public BinaryTreeNode<TNode> Left { get; set; }
        public BinaryTreeNode<TNode> Right { get; set; }
        public TNode Value { get; private set; }

        public BinaryTreeNode(TNode value)
        {
            Value = value;
        }

        public int CompareTo(TNode other)
        {
            return Value.CompareTo(other);
        }
    }
}
