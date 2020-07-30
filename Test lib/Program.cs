using Assistant.Collections;
using InvalidPassports;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Net;
using System.Threading;
using System.Xml;
using static Assistant.Converter;
using ParametersCollection = System.Collections.Generic.Dictionary<string, object>;

namespace Assistant
{
    class Program
    {
        private static string response = string.Empty;

        static void Main(string[] args)
        {
            //BaseFactory dl = new BaseFactory(DbType.Test); 
            //int res = 0;
            //BaseFactoryUniversalFunc();
            //BaseFactoryTest();
            //TestImap();
            //res = TestExecute(dl);

            //Xml(dl);

            //res = TestUpdate(dl);

            //TestMailFactory();

            //Console.WriteLine($"Updated row Id = {res}, from table dt_types_estate");

            //response = PharmacyIteraction2(hostUrl, content);
            //RestIteraction();
            //TestRound();
            //string input = "(()())(())";

            //Console.WriteLine(RemoveOuterParentheses(input));

            //Console.WriteLine(MakeCode("pack_mail.upd_mail", ESqlType.Function));

            //Test Binary tree
            //TestBinaryTree();
            //FileUploaderTest();
            XmlParser();

            Console.ReadKey();
        }

        private static void XmlParser()
        {
            //string input = "<Ais><msg type='AddendumList'>3519882,3519881,3519880,</msg></Ais>";
            //string res = XmlUtil.GetValueFromSpecAttribute(input, "type", "AddendumList");
            string res = null;
            var input = new StreamReader("xmldata.xml").ReadToEnd();
            
            var reader = new XmlTextReader(new StringReader(input));
            reader.WhitespaceHandling = WhitespaceHandling.None;
            while (reader.Read())
                if (reader.NodeType == XmlNodeType.Element)
                    if (reader.GetAttribute("type") == "AddendumList")
                        break;
            res = reader.ReadString();
            Console.WriteLine(res);
        }

        private static void FileUploaderTest()
        {
            FileStore store = new FileStore(new WebFileDownLoader(), new FileSaver());
            store.Process();
        }

        private static void TestBinaryTree()
        {
            BinaryTree<int> instance = new BinaryTree<int>();

            instance.Add(8);    //                        8
            instance.Add(5);    //                      /   \
            instance.Add(12);   //                     5    12 
            instance.Add(3);    //                    / \   / \  
            instance.Add(7);    //                   3   7 10 15                                                             
            instance.Add(10);   //                        /     \  
            instance.Add(15);   //                        1     71 
            instance.Add(71);   //
            instance.Add(1);   //
            
            //instance.InOrderTraversal(); // 3 5 7 8 12 10 15
            //instance.PostOrderTraversal(); // 3 7 5 8 10 15 12 8
            //instance.PreOrderTraversal(); // 8 5 3 7 12 10 15 
            //instance.IterativeTraversal();

            foreach (int n in instance)
            {
                Console.WriteLine(n);
            }
        }

        /// <summary>
        /// Формирование кода - запроса в базу данных
        /// </summary>
        /// <param name="progName">Название пакета, процедура. Ex. PkTaskJob.Find</param>
        /// <param name="type">Тип исполняемой комманды. Ex. ESqlType.Function</param>
        /// <returns></returns>
        /// <example>
        /// Console.WriteLine(MakeCode("PkTaskJob.GetById", ESqlType.Function));
        /// </example>
        public static string MakeCode(string progName, ESqlType type)
        {
            string header = "using (Sql sql = new Sql(0, \"Main\", \"@ProgramName\", ESqlType.@Type))\r\n{\r\nusing (Query query = new Query(this))\r\n{\r\n";
            string body = "";
            string footer = "if (query.Run(sql))\r\n{\r\nInit(query.Table);\r\nreturn true;\r\n}\r\n}\r\n}\r\nreturn false;\r\n";

            header = header.Replace("@ProgramName", progName).Replace("@Type", type.ToString());
            string connectionString = "Data Source = 10.44.0.71:1521/insbcp; Persist Security Info = True; User ID = INSURADM; Password = AisIngo";
            OracleConnection cn = new OracleConnection(connectionString);
            cn.Open();
            OracleCommand cmd = new OracleCommand(progName, cn);
            cmd.CommandType = CommandType.StoredProcedure;

            OracleCommandBuilder.DeriveParameters(cmd);
            string parameter = "query.Params.Add(\"@Name\", OracleDbType.@DataType).Value = @Name;";
            foreach (OracleParameter p in cmd.Parameters)
            {
                string temp = parameter.Replace("@Name", p.ParameterName).Replace("@DataType", p.OracleDbType.ToString()) + Environment.NewLine;
                body = string.Concat(body, temp);
            }

            return header + body + footer;
        }
        private static string RemoveOuterParentheses(string s)
        {
            char[] inpArr = s.ToCharArray();

            for (int i = 0, cnt = 0; i < inpArr.Length; i++)
                if (s[i] == '(' && cnt++ == 0)
                    inpArr[i] = ' ';
                else if (s[i] == ')' && --cnt == 0)
                    inpArr[i] = ' ';

            return new string(inpArr).Replace(" ", "");
        }

        private static void TestRound()
        {
            decimal amt = 56.50M;
            decimal percent = 15M;

            decimal subtrahend = Math.Round(amt * percent / 100, 2, MidpointRounding.AwayFromZero);
            Console.WriteLine($"delim = {subtrahend}");

            decimal newAmt = amt - subtrahend;
            
            Console.WriteLine($"{amt} - ({amt} * {percent} / 100) = {newAmt}");
        }

        private static void RestIteraction()
        {
            string hostUrl = "http://95.67.20.110:8237/aws/api/v1/json";
            string content = "{ ApiKey:\"11ea2b6ab6e3592fd15bcb420f0631f1\", Category:\"aws\", Method:\"getRegionsDictionary\"}";;

            using(RestClient rc = new RestClient(hostUrl, true, true))
            {
                response += rc.SendRequest(content, "post", @"application/json") + Environment.NewLine;
                Thread.Sleep(1000);
                response += rc.SendRequest(content, "post", @"application/json") + Environment.NewLine;
            }

        }

        private static void BaseFactoryTest()
        {
            BaseFactory bf = new BaseFactory(DbType.Work);

            DataTable dt = bf.SelectToTable("pack_street.sel_street", 16);
            //DataTable dt = bf.SelectToTableByParName("pack_street.find_street", "p_st_ci_id", 1141);
        }

        private static void BaseFactoryUniversalFunc()
        {
            DataTable dt = new DataTable();
            object result;
            DataSet ds = new DataSet();

            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["Assistant.Properties.Settings.Test"];
            // "System.Data.OracleClient"
            dt = BaseFactoryUniversal.GetProviderFactoryClasses();
            using (BaseFactoryUniversal ubf = new BaseFactoryUniversal("System.Data.OracleClient", settings.ConnectionString))
            {
                //dt = ubf.GetProviderFactoryClasses();
                //dt = ubf.SelectToTable("pack_street.sel_street", 16);
                //var pars = new Dictionary<string, object>(){ {"p_st_ci_id", 1141} };
                //result = ubf.Scalar("pack_street.find_street", pars);
                //dt = ubf.SelectToTable("pack_street.find_street", pars);

                var pars = new Dictionary<string, object>(){ {"p_obl_id", 1002} };

                ds = ubf.SelectToDataSet("OPEN_TWO_CURSORS", pars);
            }
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

        private static int TestUpdate(BaseFactory dl)
        {
            int res;
            var pars = new ParametersCollection() {
                { "p_te_id", 271 },
                { "p_te_parent_id", 123 },
                { "p_te_cod_ibc", 1604 },
                { "p_te_active", "N" }
            };

            //pars.Add("p_te_parent_id", 123);
            //pars.Add("p_te_cod_ibc", 1604);
            //pars.Add("p_te_name", "Test Update");
            //pars.Add("p_te_rate", 777);

            res = Convert.ToInt32(dl.Update("pack_dt_types_estate.upd_dt_types_estate", pars));
            return res;
        }

        private static void Xml(BaseFactory dl)
        {
            DataSet ds = dl.Select("pack_city.find");
            DataTable dt = ds.Tables[0];
            dt.WriteXml("City.xml");
        }

        private static int TestExecute(BaseFactory dl)
        {
            int res = dl.Execute("pack_debug_info.upd_debug_info", 16, "Test method execute with call procedure.");
            res = dl.Execute("pack_debug_info.upd_debug_infoFunc", 16, "Test method execute with call function.");
            return res;
        }
    }
}
