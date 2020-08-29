using InvalidPassports;
using System;
using System.Net;
using System.Text;
using System.Threading;

namespace TestLib.Controllers
{
    public class ServiceTest : ITestLib
    {
        private string response = string.Empty;

        public void DoAction()
        {
            throw new NotImplementedException();
        }
        private void RestIteraction()
        {
            string hostUrl = "http://95.67.20.110:8237/aws/api/v1/json";
            string content = "{ ApiKey:\"11ea2b6ab6e3592fd15bcb420f0631f1\", Category:\"aws\", Method:\"getRegionsDictionary\"}"; ;

            using (RestClient rc = new RestClient(hostUrl, true, true))
            {
                response += rc.SendPostRequest(content, @"application/json") + Environment.NewLine;
                Thread.Sleep(1000);
                response += rc.SendPostRequest(content, @"application/json") + Environment.NewLine;
            }

        }
        private static string MtsbuRest()
        {
            string hostUrl = "http://soabalancerdev.ingo.office:8011/MTSBU-REST/Dicts/GetMarks/";
            string marksJson = null;
            WebClient wc = new WebClient { Proxy = null };
            wc.Encoding = Encoding.UTF8;  //Кроказябры получатся без нее
            marksJson = wc.DownloadString(hostUrl);

            //using (RestClient rc = new RestClient(hostUrl))
            //{
            //    marksJson = rc.SendGetRequest(@"application/json");
            //}

            return marksJson;
        }


    }
}
