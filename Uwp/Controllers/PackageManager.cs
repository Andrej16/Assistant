using System;
using System.Threading.Tasks;
using Uwp.Core;

namespace Uwp.Controllers
{
    public class PackageManager : ITest
    {
        public MainPage Page { get; }

        public PackageManager(MainPage page)
        {
            Page = page;
        }
        public void DoAction()
        {
            //var result = InStringIndex("select arg from", "arg"); //SpliceText("selct", "lc", "ts");
            //var result = IncludeString("select", "test", 3);
            //var result = SpliceText("procedure FormatRow (ioRow in out IdentifyDictionary%RowType);", "FormatRow", "InsertField");
            string packageText = Page.PackageText;
            string findText = Page.FindText;
            //var result = WholeWordPosition("function GetDic(idiscriminator identifydictionary.discriminator%type) return sys_refcursor; ", "discriminator", 0);
            var result = WholeWordPosition(packageText, findText);
            Page.Output = "Start index: " + result.ToString();
        }
        private string IncludeFieldInPackageProcedures()
        {
            return null;
        }
        private string SpliceText(string text, string search, string toInsert)
        {
            Task<string> task = Task.Factory.
                StartNew(() => InStringIndex(text, search)).
                ContinueWith((t) => IncludeString(text, toInsert, t.Result));
            return task.Result;
        }
        private int WholeWordPosition(string text, string pattern, int start = 0)
        {
            char[] search = pattern.ToCharArray();
            int si = 0, ti = start;
            bool isCompleted = false;
            bool isFirstSpace = false;

            while (ti < text.Length)
            {
                
                if (si == 0 && !isFirstSpace)
                {
                    if (text[ti] == '\u0020' //пробел
                        || text[ti] == '\u000A' //новая строка 
                        || text[ti] == '\u0028' //левая скобка - (
                        || text[ti] == '\u0025' //%
                        || text[ti] == '\u002E') // . точка
                        isFirstSpace = true;
                }
                else if (si < search.Length)
                {
                    if (text[ti] == search[si])
                        si++;
                    else 
                    {
                        si = 0;
                        isFirstSpace = false;
                    }                        
                }
                else if (si == search.Length)
                {
                    if ((text[ti] == '\u0020' // пробел
                        || text[ti] == '\u000A' // новая строка 
                        || text[ti] == '\u0028' // левая скобка - (
                        || text[ti] == '\u0025' // %
                        || text[ti] == '\u002E') // . точка
                        && isFirstSpace)
                    {
                        isCompleted = true;
                        break;
                    }
                    else
                    {
                        si = 0;
                        isFirstSpace = false;
                    }
                }
                ti++;
            }
            return isCompleted ? ti - si : 0;
        }
        private int InStringIndex(string text, string pattern, int start = 0)
        {
            char[] search = pattern.ToCharArray();
            int si = 0, ti = start;
            bool isCompleted = false;

            for (; ti < text.Length; ti++)
            {
                if (si < search.Length && text[ti] == search[si])
                {
                    si++;
                }
                if (si == search.Length)
                {
                    isCompleted = true;
                    break;
                }
            }
            return isCompleted ? ti - (si - 1) : 0;
        }
        private string IncludeString(string text, string toInsert, int startIndex)
        {
            char[] buffer = new char[text.Length + toInsert.Length];
            int bi = 0, ti = 0;
            while (ti < startIndex)
                buffer[bi++] = text[ti++];
            for (int i = 0; i < toInsert.Length; i++)
                buffer[bi++] = toInsert[i];
            while (bi < buffer.Length)
                buffer[bi++] = text[ti++];
            return new string(buffer);
        }

    }
}
