using System;
using System.Collections;
using System.Collections.Generic;

namespace AlgorithmAndDataStruct
{
    internal class BinaryTreeEnum<T> : IEnumerator<T> where T : IComparable<T>
    {
        private BinaryTreeNode<T> _head;
        private BinaryTreeNode<T> _current;
        private bool _isLeftSubTree;
        private bool _isFirstLap;

        public BinaryTreeEnum(BinaryTreeNode<T> head)
        {
            _head = head;
            _current = head;
            _isLeftSubTree = true;
            _isFirstLap = true;
        }

        public T Current => _current.Value;

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (_isFirstLap)
            {
                _isFirstLap = false;
                return true;
            }
                
            if (_isLeftSubTree)
            {                
               LeftTreeTraversal();
            }           

            if (!_isLeftSubTree)                
                RightTreeTraversal();            

            return !(_current is null);
        }

        private void LeftTreeTraversal()
        {
            BinaryTreeNode<T> temp;

            if (_current.Left != null)
            {
                _current = _current.Left;
                while (_current.Right != null)
                    _current = _current.Right;
            }
            else
            {
                do
                {
                    temp = _current;
                    _current = _current.Parent;
                } while (_current != null && temp == _current.Left);
            }
            if (_current is null)
            {
                _isLeftSubTree = false;
                _current = _head;
            }
        }
        private void RightTreeTraversal()
        {
            BinaryTreeNode<T> temp;

            if (_current.Right != null)
            {
                _current = _current.Right;
                while (_current.Left != null)
                    _current = _current.Left;
            }
            else
            {
                do
                {
                    temp = _current;
                    _current = _current.Parent;
                } while (_current != null && temp == _current.Right);
            }
        }
        public void Reset()
        {
            _current = _head;
            _isLeftSubTree = true;
        }
        public void Dispose()
        {
            _current = _head = null;
        }
    }
}
