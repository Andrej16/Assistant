using Assistant.Core;
using Assistant.Helpers;
using System.IO;

namespace TestLib.Controllers
{
    public class StringHtmlHelperTest : ITestLib
    {
        public void DoAction()
        {
            FindOutOfTagRangeById();
        }

        private async void FindOutOfTagRangeById()
        {
            StreamReader reader = File.OpenText(@"D:\OneDrive\.NET Framework projects\Work programs\Assistant\Test lib\Data\WorksheetTemplate.html");
            string source = await reader.ReadToEndAsync();
            int startIndex, endIndex;
            string id = "AdvisoryReviewSummary";
            StringHtmlHelper.FindTagRangeById(source, id, out startIndex, out endIndex);

            source = source.Remove(startIndex, endIndex - startIndex);

            System.Console.WriteLine($"start index: {startIndex}, end index: {endIndex}\r\nRemove AdvisoryReviewSummary \r\n{source}");
        }
    }
}
