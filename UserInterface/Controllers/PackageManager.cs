using System;
using System.Threading.Tasks;

namespace UserInterface.Controllers
{
    //public class PackageManager : ITestLib
    //{
    //    public void DoAction()
    //    {
    //        //var result = InStringIndex("select arg from", "arg"); //SpliceText("selct", "lc", "ts");
    //        //var result = IncludeString("select", "test", 3);
    //        var result = SpliceText("procedure FormatRow (ioRow in out IdentifyDictionary%RowType);", "FormatRow", "InsertField");
    //        Console.WriteLine(result);
    //    }
    //    private string IncludeFieldInPackageProcedures()
    //    {
    //        return null;
    //    }
    //    private string SpliceText(string text, string search, string toInsert)
    //    {
    //        Task<string> task = Task.Factory.
    //            StartNew(() => InStringIndex(text, search)).
    //            ContinueWith((t) => IncludeString(text, toInsert, t.Result));
    //        return task.Result; 
    //    }
    //    private int InStringIndex(string text, string pattern, int start = 0)
    //    {
    //        char[] search = pattern.ToCharArray();
    //        int si = 0, ti = start;
    //        bool isCompleted = false;

    //        for (; ti < text.Length; ti++)
    //        {
    //            if (si < search.Length && text[ti] == search[si])
    //            { 
    //                si++;
    //            }
    //            if(si == search.Length)
    //            {
    //                isCompleted = true;
    //                break;
    //            }                    
    //        }
    //        return isCompleted ? ti - (si - 1) : 0;
    //    }
    //    private string IncludeString(string text, string toInsert, int startIndex)
    //    {
    //        char[] buffer = new char[text.Length + toInsert.Length];
    //        int bi = 0, ti = 0;
    //        while (ti < startIndex)
    //            buffer[bi++] = text[ti++];
    //        for (int i = 0; i < toInsert.Length; i++)
    //            buffer[bi++] = toInsert[i];
    //        while (bi < buffer.Length)
    //            buffer[bi++] = text[ti++];
    //        return new string(buffer);
    //    }
        //private string SpliceText(string text, string searchText, string toInsert)
        //{
        //    char[] insertArr = toInsert.ToCharArray();
        //    char[] search = searchText.ToCharArray();
        //    int si = 0;
        //    char[] buffer = new char[text.Length + toInsert.Length];
        //    int bi = 0;
        //    bool sequenceInProgress = false;
        //    char[] fccBuffer = new char[search.Length];
        //    int fcci = 0;
        //    bool isCompleted = false;
        //    bool isInsertedCurrent = false;

        //    for (int i = 0; i < text.Length; i++)
        //    {
        //        if (!isCompleted)
        //        {
        //            if (si < search.Length && text[i] == search[si])
        //            {
        //                si++;
        //                sequenceInProgress = true;
        //            }

        //            if (sequenceInProgress)
        //            {
        //                fccBuffer[fcci++] = text[i];
        //            }
        //            else if (fcci > 0)
        //            {
        //                foreach (var c in fccBuffer)
        //                {
        //                    buffer[bi++] = c;
        //                    fcci = 0;
        //                    fccBuffer = new char[search.Length];
        //                }
        //            }
        //            if (si == search.Length)
        //            {
        //                foreach (var c in insertArr)
        //                {
        //                    buffer[bi++] = c;
        //                    i--;
        //                }
        //                si = 0;
        //                isCompleted = true;
        //                isInsertedCurrent = true;
        //            }
        //        }
        //        if (!isInsertedCurrent)
        //            if (si == 0)
        //                buffer[bi++] = text[i];
        //        sequenceInProgress = false;
        //        isInsertedCurrent = false;
        //    }
        //    return new string(buffer);
        //}
//    }
}
