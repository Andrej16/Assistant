using System;
using System.Collections;
using System.Collections.Generic;

namespace AlgorithmAndDataStruct
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
        public BinaryTreeNode<T> Head { get; set; }
        public int Count { get; private set; }
        #region Add
        public void Add(T value)
        {
            // Первый случай: дерево пустое     

            if (Head == null)
            {
                BinaryTreeNode<T> newNode = new BinaryTreeNode<T>(value);
                Head = newNode;

            }

            // Второй случай: дерево не пустое, поэтому применяем рекурсивный алгоритм 
            //                для поиска места добавления узла        

            else
            {
                AddTo(Head, value);
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
            BinaryTreeNode<T> current = Head;
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
            InOrderTraversal(Head);
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
            PostOrderTraversal(Head);
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
            PreOrderTraversal(Head);
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
            IterativeTraversal(Head);
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
        #region IterativeTreeWalk Queue
        //        8
        //      /   \
        //     5    12 
        //    / \   / \  
        //   3   7 10 15                                                             
        //  /           \  
        // 1             71 
        //Output: 8 5 12 3 7 10 15 1 71
        public void IterativeQueueTraversal()
        {
            IterativeQueueTraversal(Head);
        }
        private void IterativeQueueTraversal(BinaryTreeNode<T> head)
        {
            if (head is null)
                return;

            Queue<BinaryTreeNode<T>> queue = new Queue<BinaryTreeNode<T>>();
            queue.Enqueue(head);
            while(queue.Count > 0)
            {
                BinaryTreeNode<T> temp = queue.Dequeue();
                Console.WriteLine(temp.Value);

                if (temp.Left != null)
                    queue.Enqueue(temp.Left);
                if (temp.Right != null)
                    queue.Enqueue(temp.Right);
            }
        }
        #endregion
        #region IterativeInorderTraversal Queue
        //        8
        //      /   \
        //     5    12 
        //    / \   / \  
        //   3   7 10 15                                                             
        //  /           \  
        // 1             71 
        //Output: 5 3 7 1 8 12 10 15 71
        public void IterativeQueueInorderTraversal()
        {
            IterativeQueueInorderTraversal(Head);
        }
        private void IterativeQueueInorderTraversal(BinaryTreeNode<T> head)
        {
            if (head is null)
                return;

            Queue<BinaryTreeNode<T>> queue = new Queue<BinaryTreeNode<T>>();
            if(head.Left != null)
            {
                queue.Enqueue(head.Left);
                while (queue.Count > 0)
                {
                    BinaryTreeNode<T> temp = queue.Dequeue();
                    Console.WriteLine(temp.Value);

                    if (temp.Left != null)
                        queue.Enqueue(temp.Left);
                    if (temp.Right != null)
                        queue.Enqueue(temp.Right);
                }
            }
            Console.WriteLine(head.Value);
            if (head.Right != null)
            {
                queue.Enqueue(head.Right);
                while (queue.Count > 0)
                {
                    BinaryTreeNode<T> temp = queue.Dequeue();
                    Console.WriteLine(temp.Value);

                    if (temp.Left != null)
                        queue.Enqueue(temp.Left);
                    if (temp.Right != null)
                        queue.Enqueue(temp.Right);
                }
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
            return new BinaryTreeEnum<T>(Head);
        }
        #endregion
        public void Insert(T value)
        {
            TreeInsertRecursive(Head, new BinaryTreeNode<T>(value));
        }
        private void TreeInsertRecursive(BinaryTreeNode<T> current, BinaryTreeNode<T> newNode)
        {
            if(current is null)
            {
                Head ??= newNode;
                Count++;
                return;
            }

            if (newNode.CompareNode(current) < 0)
            {
                TreeInsertRecursive(current.Left, newNode);
                current.Left ??= newNode;
                current.Left ??= current;
            }
            else
            {
                TreeInsertRecursive(current.Right, newNode);
                current.Right ??= newNode;
                current.Right ??= current;
            }
        }
        /// <summary>
        /// LeetCode. Сравнивает два дерева на идентичность структуры и значений
        /// </summary>
        /// <see cref="https://leetcode.com/problems/same-tree/"/>
        public static bool IsSameTree(BinaryTreeNode<int> p, BinaryTreeNode<int> q)
        {
            if (p.Left != null && q.Left is null)
                return false;
            if (p.Left is null && q.Left != null)
                return false;
            if (p.Left != null && q.Left != null)
            {
                if (!IsSameTree(p.Left, q.Left))
                    return false;
            }
            if (p.Right != null && q.Right is null)
                return false;
            if (p.Right is null && q.Right != null)
                return false;
            if (p.Right != null && q.Right != null)
            {
                if (!IsSameTree(p.Right, q.Right))
                    return false;
            }
            return p.Value == q.Value;
        }
    }
}
