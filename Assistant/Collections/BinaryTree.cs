using System;
using System.Collections;
using System.Collections.Generic;

namespace Assistant.Collections
{
    /// <summary>
    /// Двоичное дерево поиска
    /// </summary>
    /// <example>
    /// private static void TestBinaryTree()
    /// {
    ///     BinaryTree<int> instance = new BinaryTree<int>();
    ///
    ///     instance.Add(8);    //                        8
    ///     instance.Add(5);    //                      /   \
    ///     instance.Add(12);   //                     5    12 
    ///     instance.Add(3);    //                    / \   / \  
    ///     instance.Add(7);    //                   3   7 10 15                                                             
    ///     instance.Add(10);   //                        /     \  
    ///     instance.Add(15);   //                        1     71 
    ///     instance.Add(71);   //
    ///     instance.Add(1);   //
    ///     
    ///     //instance.InOrderTraversal(); // 3 5 7 8 12 10 15
    ///     //instance.PostOrderTraversal(); // 3 7 5 8 10 15 12 8
    ///     //instance.PreOrderTraversal(); // 8 5 3 7 12 10 15 
    ///     //instance.IterativeTraversal();
    ///
    ///     foreach (int n in instance)
    ///     {
    ///         Console.WriteLine(n);
    ///     }
    /// }
    /// </example>
    public class BinaryTree<T> : IEnumerable<T> where T : IComparable<T>
    {
        private BinaryTreeNode<T> _head;
        public int Count { get; private set; }
        #region Add
        public void Add(T value)
        {
            // Первый случай: дерево пустое     

            if (_head == null)
            {
                BinaryTreeNode<T> newNode = new BinaryTreeNode<T>(value);
                _head = newNode;

            }

            // Второй случай: дерево не пустое, поэтому применяем рекурсивный алгоритм 
            //                для поиска места добавления узла        

            else
            {
                AddTo(_head, value);
            }
            Count++;
        }
        // Рекурсивный алгоритм 
        private void AddTo(BinaryTreeNode<T> node, T value)
        {
            // Первый случай: значение добавляемого узла меньше чем значение текущего. 

            if (value.CompareTo(node.Value) < 0)
            {
                // если левый потомок отсутствует - добавляем его          

                if (node.Left == null)
                {
                    BinaryTreeNode<T> newNode = new BinaryTreeNode<T>(value);
                    node.Left = newNode;
                    newNode.Parent = node;
                }
                else
                {
                    // повторная итерация               
                    AddTo(node.Left, value);
                }
            }
            // Второй случай: значение добавляемого узла равно или больше текущего значения      
            else
            {
                // Если правый потомок отсутствует - добавлем его.          

                if (node.Right == null)
                {
                    BinaryTreeNode<T> newNode = new BinaryTreeNode<T>(value);
                    node.Right = newNode;
                    newNode.Parent = node;
                }
                else
                {
                    // повторная итерация

                    AddTo(node.Right, value);
                }
            }
        }
        #endregion
        #region Search
        public bool Contains(T value)
        {
            return FindWithParent(value, out BinaryTreeNode<T> parent) != null;
        }
        // Метод FindWithParent возвращает первый найденный узел.
        // Если значение не найдено, метод возвращает null.
        // Так же возвращает родительский узел для найденного значения.
        private BinaryTreeNode<T> FindWithParent(T value, out BinaryTreeNode<T> parent)
        {
            // Поиск значения в дереве.     
            BinaryTreeNode<T> current = _head;
            parent = null;

            while (current != null)
            {
                int result = current.CompareTo(value);
                if (result > 0)
                {
                    // Если искомое значение меньше значение текущего узла - переходим к левому потомку.             
                    parent = current;
                    current = current.Left;
                }
                else if (result < 0)
                {
                    // Если искомое значение больше значение текущего узла - переходим к правому потомку.
                    parent = current;
                    current = current.Right;
                }
                else
                {
                    // Искомый элемент найден             
                    break;
                }
            }
            return current;
        }
        #endregion
        #region InOrder
        public void InOrderTraversal()
        {
            InOrderTraversal(_head);
        }
        private void InOrderTraversal(BinaryTreeNode<T> node)
        {
            if (node.Left != null)
                InOrderTraversal(node.Left);

            Console.WriteLine(node.Value);

            if (node.Right != null)
                InOrderTraversal(node.Right);
        }
        #endregion
        #region PostOrder
        public void PostOrderTraversal()
        {
            PostOrderTraversal(_head);
        }
        private void PostOrderTraversal(BinaryTreeNode<T> node)
        {
            if (node.Left != null)
                PostOrderTraversal(node.Left);

            if (node.Right != null)
                PostOrderTraversal(node.Right);

            Console.WriteLine(node.Value);
        }
        #endregion
        #region PreOrder
        public void PreOrderTraversal()
        {
            PreOrderTraversal(_head);
        }
        private void PreOrderTraversal(BinaryTreeNode<T> node)
        {
            Console.WriteLine(node.Value);

            if (node.Left != null)
                PreOrderTraversal(node.Left);

            if (node.Right != null)
                PreOrderTraversal(node.Right);
        }
        #endregion
        #region Iterative traversal
        public void IterativeTraversal()
        {
            IterativeTraversal(_head);
        }
        private void IterativeTraversal(BinaryTreeNode<T> head)
        {
            BinaryTreeNode<T> current = head;
            BinaryTreeNode<T> temp;
            //Обход правого поддерева
            while (current != null)
            {
                current?.Print();
                if (current.Right != null)
                {
                    current = current.Right;
                    while (current.Left != null)
                        current = current.Left;
                }
                else
                {
                    do
                    {
                        temp = current;
                        current = current.Parent;
                    } while (current != null && temp == current.Right);
                }
            }
            //Обход левого поддерева
            current = head;
            while (current != null)
            {
                if (current.Left != null)
                {
                    current = current.Left;
                    while (current.Right != null)
                        current = current.Right;
                }
                else
                {
                    do
                    {
                        temp = current;
                        current = current.Parent;
                    } while (current != null && temp == current.Left);
                }
                current?.Print();
            }
        }
        #endregion
        #region Нумератор
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public IEnumerator<T> GetEnumerator()
        {
            return new BinaryTreeEnum<T>(_head);
        }
        #endregion
    }
}
