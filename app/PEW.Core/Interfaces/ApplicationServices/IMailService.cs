using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PEW.Core.Interfaces.ApplicationServices
{
    public interface IMail
    {
        string Id { get; set; }
        string From { get; set; }
        string To { get; set; }
        string Message { get; set; }
        string Subject { get; set; }
    }

    public interface IMailService
    {
        /// <summary>
        /// Send a mail through smtp with your gmail account
        /// </summary>
        /// <param name="mail"></param>
        void Send(string emailAddress, string password, IMail mail);

        /// <summary>
        /// Delete a mail
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <param name="password"></param>
        /// <param name="mail"></param>
        void Delete(string emailAddress, string password, IMail mail);

        /// <summary>
        /// Delete a list of mails
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <param name="password"></param>
        /// <param name="mails"></param>
        void Delete(string emailAddress, string password, IEnumerable<IMail> mails);

        /// <summary>
        /// Get the mails in your inbox
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        IEnumerable<IMail> GetInbox(string emailAddress, string password);

        /// <summary>
        /// Gets the latest mail in our inbox
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        IMail GetLatestMail(string emailAddress, string password);

        /// <summary>
        /// Clears your inbox
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <param name="password"></param>
        void ClearInbox(string emailAddress, string password);
    }
}
