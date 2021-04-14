using AlgorithmAndDataStruct.LinkedList;
using Assistant.Core;
using System;

namespace TestLib.Controllers
{
    public class LlPackageManager : ITestLib
    {
        public void DoAction()
        {
            string packageText = Console.ReadLine();
            LinkedList<char> ll = new LinkedList<char>();
            var res = ll.Fill(packageText);
            Console.WriteLine(res);
        }

    }
}
