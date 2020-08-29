using Assistant;
using System;

namespace TestLib.Controllers
{
    public class MailTest : ITestLib
    {
        public void DoAction()
        {
            throw new NotImplementedException();
        }
        private static void TestImap()
        {
            using (Imap imap = new Imap("imap.gmail.com", 993, "andrej.shilin@gmail.com", "!qaz@wsx"))
            {
                //imap.Prepare("proxy", 8080);
                imap.Prepare();
                string list = imap.GetListFolders();

                Console.WriteLine(list);

                while (imap.Get())
                {
                    Console.WriteLine("Subject " + Environment.NewLine +
                        imap["header"] + Environment.NewLine +
                        "Body" + Environment.NewLine +
                        imap["body"]);
                }

            }
        }

        private static void TestMailFactory()
        {
            using (MailFactory mf = new MailFactory("pluton.ingo.office"))
                mf.SendMail("ingo@ingo.ua", "ashilin@ingo.ua", "Message body", "Message subject", "City.xml");
        }

    }
}
