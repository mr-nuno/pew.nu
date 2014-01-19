using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml;
using PEW.Core.Interfaces.ApplicationServices;

namespace PEW.ApplicationServices
{
    public class GMailService : IMailService
    {
        public void Send(string emailAddress, string password, IMail mail)
        {
            throw new NotImplementedException();
        }

        public void Delete(string emailAddress, string password, IMail mail)
        {
            throw new NotImplementedException();
        }

        public void Delete(string emailAddress, string password, IEnumerable<IMail> mails)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IMail> GetInbox(string emailAddress, string password)
        {
            throw new NotImplementedException();
        }

        public IMail GetLatestMail(string emailAddress, string password)
        {
            throw new NotImplementedException();
        }

        public void ClearInbox(string emailAddress, string password)
        {
            throw new NotImplementedException();
        }
    }
}
