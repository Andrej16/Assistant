using System.Net;
using InvalidPassports.Interfaces;

namespace InvalidPassports
{
    public class WebFileDownLoader : IFileDownLoader
    {
        private WebClient _webClient;
        public WebFileDownLoader()
        {
            _webClient = new WebClient();
            WebProxy proxy = new WebProxy("proxy", 8080);
            proxy.Credentials = CredentialCache.DefaultCredentials;
            _webClient.Proxy = proxy;
        }
        public bool Download(IAddressBuilder builder, string localPath)
        {
            string addressComplete = builder.Build();
            try
            {
                _webClient.DownloadFile(addressComplete, localPath);
                return true;
            }
            catch(WebException ex)
            {
                return false;
            }
        }
    }
}
