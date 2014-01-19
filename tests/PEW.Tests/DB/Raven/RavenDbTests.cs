using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using PEW.Core.Data;
using PEW.Core.Domain;
using PEW.Core.Interfaces.Data;
using PEW.Data;
using PEW.Repository;

namespace PEW.Tests.DB.Raven
{
    [TestFixture]
    public class RavenDbTests
    {
        private IRavenDbDataContext _dbContext;

        [SetUp]
        public void Setup()
        {
            _dbContext = new RavenDbContext();
        }

        [Test]
        public void CRUD_operations_on_profile_should_be_persisted()
        {
            var unitOfWork = new UnitOfWork(_dbContext);
            var repo = new ProfileRepository(_dbContext);
            
            repo.Add(Profile.Create("mr_nuno", "nhl-13", "ps3"));
            unitOfWork.Commit();

            Assert.Greater(repo.GetAll().Count(), 0);

            var p = repo.First();
            const string email = "rav@en.net";
            p.Email = email;
            unitOfWork.Commit();

            p = repo.First();
            Assert.AreEqual(email, p.Email);

            repo.Delete(p);
            unitOfWork.Commit();

            Assert.AreEqual(0, repo.GetAll().Count());
        }

        [TearDown]
        public void Teardown()
        {
            _dbContext.Dispose();
        }
    }
}
