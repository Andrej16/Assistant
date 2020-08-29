using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace InvalidPassports
{
    /// <summary>
    /// Class for sending HTTP requests and receiving HTTP responses from a resource identified by a URI.
    /// </summary>
    public class RestClient : IDisposable
    {
        /// <summary>
        /// Endpoint
        /// </summary>
        private string hostUrl;
        private HttpClient client;
        private HttpClientHandler handler;
        private bool needDefaultCredentials = false;
        private CookieContainer cookies;
        // Для определения избыточных вызовов
        private bool disposedValue = false;
        #region IDisposable Support
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        ~RestClient()
        {
            Dispose(false);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    //Освободить управляемые ресурсы
                    cookies = null;
                }
                //Освободить не управляемые ресурсы
                handler?.Dispose();
                client?.Dispose();

                disposedValue = true;
            }
        }
        #endregion
        /// <summary>
        /// Initializes a new instance of the HttpClient class.
        /// </summary>
        /// <param name="host">Service end point adress</param>
        /// <param name="needDefCredentials">Gets or sets a value that controls whether default credentials are sent with requests by the handler.</param>
        /// <param name="needCoocies">Do I need to use coocies</param>
        /// <param name="usedClient">Do I need to use HttpClient</param>
        public RestClient(string host, bool needDefCredentials = false, bool needCoocies = false, bool usedClient = false)
        {
            hostUrl = host;
            cookies = needCoocies ? new CookieContainer() : null;
            needDefaultCredentials = needDefCredentials;

            if (usedClient)
            {
                handler = new HttpClientHandler
                {
                    CookieContainer = cookies,
                    UseDefaultCredentials = needDefaultCredentials
                };

                client = new HttpClient(handler);
            }
        }
        /// <summary>
        /// Send an HTTP request as an asynchronous operation.
        /// </summary>
        /// <typeparam name="T">Object, which will be serialized to send.</typeparam>
        /// <typeparam name="M">Object, which will be deserialized to send.</typeparam>
        /// <param name="contentObj">The HTTP request object to send.</param>
        /// <returns>The task object representing the response from the Internet resource.</returns>
        public async Task<M> SendRequest<T, M>(T contentObj)
        {
            //TODO : Если Т или М строка не выполнять сериализацию
            string content = JsonConvert.SerializeObject(contentObj);
            M output = default(M);

            try
            {
                var requestMessage = new HttpRequestMessage(HttpMethod.Get, hostUrl);

                requestMessage.Content = new StringContent(content);

                var response = await client.SendAsync(requestMessage);

                response.EnsureSuccessStatusCode();

                var responseString = await response.Content.ReadAsStringAsync();
                output = JsonConvert.DeserializeObject<M>(responseString);
            }
            catch (WebException e)
            {
                throw new Exception(e.Message);
            }

            return output;
        }
        /// <summary>
        /// Send request to the specified Uri 
        /// </summary>
        /// <param name="contentType">The value of the Content-type HTTP header(Ex. @"application/json").</param>
        /// <returns>Response content</returns>
        public string SendGetRequest(string contentType)
        {
            string output = null;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(hostUrl);
            request.Method = "get";
            request.ContentType = contentType;
            request.UseDefaultCredentials = needDefaultCredentials;
            request.CookieContainer = cookies;
            using (WebResponse response = request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
                output = reader.ReadToEnd();

            return output;
        }
        /// <summary>
        /// Send request to the specified Uri 
        /// </summary>
        /// <param name="content">Content to send</param>
        /// <param name="contentType">The value of the Content-type HTTP header(Ex. @"application/json").</param>
        /// <returns>Response content</returns>
        public string SendPostRequest(string content, string contentType)
        {
            string output = null;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(hostUrl);
            request.Method = "post";

            byte[] byteArray = Encoding.UTF8.GetBytes(content);
            request.ContentLength = byteArray.Length;

            request.ContentType = contentType;
            request.UseDefaultCredentials = needDefaultCredentials;

            request.CookieContainer = cookies;

            using (Stream stream = request.GetRequestStream())
                stream.Write(byteArray, 0, byteArray.Length);

            using (WebResponse response = request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
                output = reader.ReadToEnd();

            return output;
        }

    }
}
