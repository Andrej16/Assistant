using InvalidPassports;

namespace TestLib.Controllers
{
    public class InvalidPassportsProjectTest : ITestLib
    {
        public void DoAction()
        {
            FileUploaderTest();
        }
        private void FileUploaderTest()
        {
            FileStore store = new FileStore(new WebFileDownLoader(), new FileSaver());
            store.Process();
        }

    }
}
