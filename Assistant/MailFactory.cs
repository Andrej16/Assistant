using System;
using System.Net.Mail;

namespace Assistant
{
    /// <summary>
    /// Class for work with mail.
    /// </summary>
    public class MailFactory : IDisposable
    {
        private SmtpClient client;

        #region IDisposable Support
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                if (client != null)
                    client.Dispose();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
        /// <summary>
        /// Initializes a new instance of the SmtpClient class that sends email by using the specified SMTP server and port.
        /// </summary>
        /// <param name="host">Ex.: "pluton.ingo.office"</param>
        public MailFactory(string host, int port = 25)
        {
            client = new SmtpClient(host, port);
        }
        /// <summary>
        /// Sends the specified email message to an SMTP server for delivery <see cref="BaseFactory.Execute(string, object[])"/>. 
        /// </summary>
        /// <remarks>
        /// The message sender, recipients, subject, and message body are specified using String objects.
        /// </remarks>
        /// <example>
        /// using (MailFactory mf = new MailFactory("pluton.ingo.office"))
        ///     mf.SendMail("ingo@ingo.ua", "ashilin@ingo.ua", "Message body", "Message subject"); 
        /// </example>
        /// <param name="sender">Contains the address information of the message sender</param>
        /// <param name="recipients">That contains the addresses(Ex. "fname@mail.com, fname2@mail.com") that the message is sent to.</param>
        /// <param name="body">That contains the message body.</param>
        /// <param name="subject">That contains the subject line for the message.</param>
        public void SendMail(string sender, string recipients, string body, string subject)
        {
            client.Send(sender, recipients, subject, body);               
        }
        /// <summary>
        /// Sends the specified email message to an SMTP server for delivery. 
        /// </summary>
        /// <remarks>
        /// The message sender, recipients, subject, and message body are specified using String objects.
        /// </remarks>
        /// <example>
        /// using (MailFactory mf = new MailFactory("pluton.ingo.office"))
        ///     mf.SendMail("ingo@ingo.ua", "ashilin@ingo.ua", "Message body", "Message subject", "City.xml"); 
        /// </example>
        /// <param name="sender">Contains the address information of the message sender</param>
        /// <param name="recipients">That contains the addresses(Ex. "fname@mail.com, fname2@mail.com") that the message is sent to.</param>
        /// <param name="body">That contains the message body.</param>
        /// <param name="subject">That contains the subject line for the message.</param>
        /// <param name="filePaths">A String that contains a file path to use to create this attachment.</param>
        public void SendMail(string sender, string recipient, string body, string subject, params string[] filePaths)
        {
            MailMessage mm = new MailMessage(sender, recipient);

            mm.Subject = subject;
            mm.Body = body;

            foreach (var fp in filePaths)
                mm.Attachments.Add(new Attachment(fp));

            client.Send(mm);
        }

    }
}
