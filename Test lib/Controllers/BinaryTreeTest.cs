using AlgorithmAndDataStruct;

namespace TestLib
{
    public class BinaryTreeTest : ITestLib
    {
        public void DoAction()
        {
            //TestBinaryTree();
            CompareBinaryTree();
        }
        private void TestBinaryTree()
        {
            BinaryTree<int> tree = new BinaryTree<int>();

            //tree.Add(8);    //                        8
            //tree.Add(5);    //                      /   \
            //tree.Add(12);   //                     5    12 
            //tree.Add(3);    //                    / \   / \  
            //tree.Add(7);    //                   3   7 10 15                                                             
            //tree.Add(10);   //                  /           \  
            //tree.Add(15);   //                 1             71 
            //tree.Add(71);   //
            //tree.Add(1);    //

            tree.Insert(8);    //                        8
            tree.Insert(5);    //                      /   \
            tree.Insert(12);   //                     5    12 
            tree.Insert(3);    //                    / \   / \  
            tree.Insert(7);    //                   3   7 10 15                                                             
            tree.Insert(10);   //                  /           \  
            tree.Insert(15);   //                 1             71 
            tree.Insert(71);   //
            tree.Insert(1);    //

            //instance.InOrderTraversal(); // 3 5 7 8 12 10 15
            //instance.PostOrderTraversal(); // 3 7 5 8 10 15 12 8
            //instance.PreOrderTraversal(); // 8 5 3 7 12 10 15 
            //instance.IterativeTraversal(); 
            //instance.IterativeQueueTraversal(); //8 5 12 3 7 10 15 1 71
            tree.IterativeQueueInorderTraversal();

            //foreach (int n in instance)
            //{
            //    Console.WriteLine(n);
            //}
        }
        private void CompareBinaryTree()
        {
            BinaryTree<int> p = new BinaryTree<int>();

            p.Add(1);    //                        1
            p.Add(2);    //                      /   \
            p.Add(3);    //                     2     3 

            BinaryTree<int> q = new BinaryTree<int>();

            q.Add(1);    //                        1
            q.Add(2);    //                      /   \
            q.Add(3);    //                     2     3 

            bool isEquals = BinaryTree<int>.IsSameTree(p.Head, q.Head);
            if(isEquals)
                System.Console.WriteLine($"Trees is equals");
            else
                System.Console.WriteLine("Trees is not equals");
        }
    }
}
