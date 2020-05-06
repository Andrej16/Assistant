using System;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Reflection;
using System.Text;

namespace Assistant
{
    public class Imap : IDisposable
    {
        private TcpClient tcp;
        private SslStream ssl;
        private byte[] dummy;
        private string header;
        private string body;
        private string request;
        /// <summary>
        /// IMAP mail server
        /// </summary>
        public string TargetHost { get; set; }
        /// <summary>
        /// IMAP mail port
        /// </summary>
        private int TargetPort { get; set; }
        /// <summary>
        /// Proxy serber
        /// </summary>
        private string ProxyHost { get; set; }
        /// <summary>
        /// Proxy port
        /// </summary>
        private int ProxyPort { get; set; }
        //Message number
        private int number;
        // Для определения избыточных вызовов
        private bool disposedValue = false;
        /// <summary>
        /// Login
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// User password
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Lists the folders (inbox,sentmail,users labels )
        /// </summary>
        public string Folder { get; set; }

        #region IDisposable Support
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    //Logout command.
                    receiveResponse("$ LOGOUT\r\n");

                    if (ssl != null)
                    {
                        ssl.Close();
                        ssl.Dispose();
                    }
                    if (tcp != null)
                        tcp.Close();
                }

                header = null;
                body = null;
                dummy = null;

                disposedValue = true;
            }
        }
         ~Imap()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

        /// <summary>
        /// Initializes a new instance IMAP server and port.
        /// </summary>
        /// <example>
        /// using (Imap imap = new Imap("imap.gmail.com", 993, "andrej.shilin@gmail.com", "!qaz@wsx"))
        /// {
        ///     string list = imap.GetListFolders();
        ///     Console.WriteLine(list);
        /// }
        /// </example>
        /// <param name="host">Ex.: "imap.gmail.com"</param>
        public Imap(string host, int port, string user, string pass)
        {
            //Target sets
            TargetHost = host;
            TargetPort = port;
            //User configure
            UserName = user;
            Password = pass;
        }
        /// <summary>
        /// Prepare request. Create TcpClient with/without proxy. 
        /// </summary>
        /// <param name="proxy"></param>
        /// <param name="prxPort"></param>
        /// <param name="prxUserName"></param>
        /// <param name="prxPass"></param>
        public void Prepare(string proxy = null, int prxPort = 0)
        {
            //Proxy sets
            ProxyHost = proxy;
            ProxyPort = prxPort;

            if (proxy == null && prxPort == 0)
                tcp = createTcpClient(TargetHost, TargetPort);
            else
                tcp = createTcpClient(TargetHost, TargetPort, ProxyHost, ProxyPort);

            ssl = new SslStream(tcp.GetStream());
            ssl.AuthenticateAsClient(TargetHost);

            prepareRequest();
        }
        /// <summary>
        /// Define the indexer, which will allow client code 
        /// to use [] notation on the class instance itself.
        /// </summary>
        /// <param name="part">Header or Body message</param>
        public string this[string part]
        {
            get
            {
                if (part.Equals("Header", StringComparison.CurrentCultureIgnoreCase))
                    return header;
                else if (part.Equals("Body", StringComparison.CurrentCultureIgnoreCase))
                    return body;
                else
                    throw new ApplicationException("Uncnown part!");
            }
        }
        private void prepareRequest()
        {
            if (UserName == null || Password == null)
                throw new ApplicationException("Login or password not set!");

            number = 0;

            receiveResponse("");
            //Loging
            receiveResponse($"$ LOGIN {UserName} {Password} \r\n");
        }
        /// <summary>
        /// used to write the commands in network  stream and thus send  commands to the server. 
        /// It also receives the response from the server and returns string.    
        /// </summary>
        /// <param name="command">Imap command</param>
        /// <returns>Message read from box</returns>
        private string receiveResponse(string command)
        {
            try
            {
                if(command != null)
                {
                    if (tcp.Connected)
                    {
                        dummy = Encoding.ASCII.GetBytes(command);
                        ssl.Write(dummy, 0, dummy.Length);
                    }
                    else
                        throw new ApplicationException("TCP CONNECTION DISCONNECTED");
                }
                ssl.Flush();

                byte[] buffer = new byte[2048];
                ssl.Read(buffer, 0, 2048);

                string message = Encoding.ASCII.GetString(buffer);

                return message;
            }
            catch(Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }
        /// <summary>
        /// Reads the next message.
        /// </summary>
        /// <returns>Значение true, если имеются другие строки; в противном случае — значение false</returns>
        public bool Get()
        {
            if (Folder == null)
                throw new ApplicationException("Folder not set!");

            //This command is used to select a particular folder in the user's imap account.
            receiveResponse($"$ SELECT {Folder.ToUpper()}\r\n");
            //Fetches the particular email's header from the users selected folder.variable number's value is got from the user. 
            header = receiveResponse($"$ FETCH {number} body[header]\r\n");
            //Fetches the particular email's detail from the users selected folder.  
            body = receiveResponse($"$ FETCH {number} body[text]\r\n");

            number++;

            return true;
        }
        /// <summary>
        /// User folders (inbox,sentmail,users labels) 
        /// </summary>
        /// <returns></returns>
        public string GetListFolders()
        {
            //Get users folders
            request = "$ LIST \"\" \"*\"\r\n";

            return receiveResponse(request);
        }
        private TcpClient createTcpClient(string host, int port)
        {
            try
            {
                tcp = new TcpClient(host, port);
            }
            catch (SocketException sx)
            {
                throw new ApplicationException(sx.Message);
            }

            return tcp;
        }
        //Метод не проверен!!!
        private TcpClient createTcpClient(string targetHost, int targetPort, string httpProxyHost, int httpProxyPort)
        {
            WebRequest request = WebRequest.Create("http://" + targetHost + ":" + targetPort);
            //For example ("proxy", 8080);
            WebProxy webProxy = new WebProxy(httpProxyHost, httpProxyPort)
            {
                Credentials = CredentialCache.DefaultCredentials
            };

            request.Proxy = webProxy;
            request.Method = "CONNECT";

            WebResponse response = request.GetResponse();

            Stream responseStream = response.GetResponseStream();

            const BindingFlags Flags = BindingFlags.NonPublic | BindingFlags.Instance;

            Type rsType = responseStream.GetType();
            PropertyInfo connectionProperty = rsType.GetProperty("Connection", Flags);

            var connection = connectionProperty.GetValue(responseStream, null);
            Type connectionType = connection.GetType();
            PropertyInfo networkStreamProperty = connectionType.GetProperty("NetworkStream", Flags);

            var networkStream = networkStreamProperty.GetValue(connection, null);
            Type nsType = networkStream.GetType();
            PropertyInfo socketProperty = nsType.GetProperty("Socket", Flags);
            Socket socket = (Socket)socketProperty.GetValue(networkStream, null);

            return new TcpClient { Client = socket };
        }
    }
}
