using System;
using System.Net;
using System.Text;

namespace MtsbuDictionaryUpdater
{
    public class MtsbuServiceClient : IServiceClient
    {
        public string Url { get; set; }
        public MtsbuServiceClient(string url)
        {
            Url = url;
        }
        public string GetJson()
        {
            string jsonData = string.Empty;
            try
            {
                jsonData = RunRequest();
            }
            catch (Exception ex)
            {
                Log.Add(ex);
            }
            return jsonData;
        }
        private string RunRequest()
        {
            if (string.IsNullOrEmpty(Url))
                throw new ArgumentException($"{nameof(Url)} can not be null!");

            WebClient wc = new WebClient { Proxy = null };
            wc.Encoding = Encoding.UTF8;
            string dictionary = wc.DownloadString(Url);

            return dictionary;
        }
    }
}
