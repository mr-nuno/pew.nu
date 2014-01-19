using System;
using System.Linq;
using PEW.Core.Interfaces.Data;
using Raven.Client;
using Raven.Client.Document;

namespace PEW.Data
{
    public class RavenDbContext : IRavenDbDataContext
    {
        public RavenDbContext()
        {
            Store = new DocumentStore { ConnectionStringName = "RavenDb" }.Initialize();
            Session = Store.OpenSession();
        }

        public void Save()
        {
            Session.SaveChanges();
        }

        public void Dispose()
        {
            if (Session != null) Session.Dispose();
            if (Store != null) Store.Dispose();
        }

        public IDocumentStore Store { get; private set; }
        public IDocumentSession Session { get; private set; }
    }
}
