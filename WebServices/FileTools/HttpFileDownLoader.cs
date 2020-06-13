using System.IO;
using System.Net;
using System.Net.Http;

namespace InvalidPassports.FileTools
{
    public class HttpFileDownLoader 
    {
        public async void Download(string address, string localPath)
        {
            HttpClientHandler handler = new HttpClientHandler();
            WebProxy proxy = new WebProxy("proxy", 8080);
            proxy.Credentials = CredentialCache.DefaultCredentials;
            handler.Proxy = proxy;
            HttpClient client = new HttpClient(handler);

            HttpResponseMessage httpResponse = await client.GetAsync(address);
            httpResponse.EnsureSuccessStatusCode();
            using (FileStream file = File.Create(localPath))
                await httpResponse.Content.CopyToAsync(file);
        }
    }
}
