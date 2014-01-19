using System;
using Raven.Client;

namespace PEW.Core.Interfaces.Data
{
    public interface IRavenDbDataContext : IDisposable
    {
        IDocumentStore Store { get; }
        IDocumentSession Session { get; }
        void Save();
    }
}
