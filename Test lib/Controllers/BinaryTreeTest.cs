using AlgorithmAndDataStruct;

namespace TestLib
{
    public class BinaryTreeTest : ITestLib
    {
        public void DoAction()
        {
            TestBinaryTree();
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

    }
}
