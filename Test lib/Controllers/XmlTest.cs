using Assistant;
using System;
using System.Data;
using System.IO;
using System.Xml;

namespace TestLib
{
    public class XmlTest : ITestLib
    {
        public void DoAction()
        {
            XmlParser();
        }
        private void XmlParser()
        {
            //string input = "<Ais><msg type='AddendumList'>3519882,3519881,3519880,</msg></Ais>";
            //string res = XmlUtil.GetValueFromSpecAttribute(input, "type", "AddendumList");
            string res = null;
            var input = new StreamReader(@"D:\OneDrive\.NET Framework projects\Work programs\Assistant\Test lib\Data\xmldata.xml").ReadToEnd();

            var reader = new XmlTextReader(new StringReader(input));
            reader.WhitespaceHandling = WhitespaceHandling.None;
            while (reader.Read())
                if (reader.NodeType == XmlNodeType.Element)
                    if (reader.GetAttribute("type") == "AddendumList")
                        break;
            res = reader.ReadString();
            Console.WriteLine(res);
        }
        private static void Xml(BaseFactory dl)
        {
            DataSet ds = dl.Select("pack_city.find");
            DataTable dt = ds.Tables[0];
            dt.WriteXml("City.xml");
        }

    }
}
