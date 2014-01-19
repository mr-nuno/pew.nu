using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using NUnit.Framework;
using PEW.ApplicationServices;
using PEW.Core.Data;
using PEW.Core.Domain;
using PEW.Core.Interfaces;
using PEW.Core.Interfaces.ApplicationServices;
using PEW.Core.Interfaces.Data;
using PEW.Core.Validation;
using PEW.Data;
using PEW.Repository;
using PEW.Web.Api;
using PEW.Web.Api.Controllers;
using Telerik.JustMock;

namespace PEW.Tests.Controllers.Api
{
    [TestFixture]
    public class ProfileControllerTests
    {
        private IUnitOfWork _unitOfWork;

        [SetUp]
        public void Setup()
        {
            var container = new UnityContainer();

            ServiceLocator.SetLocatorProvider(() => new UnityServiceLocator(container));

            //other
            container.RegisterType<IValidator, Validator>();

            //repositories
            container.RegisterType<IProfileRepository, FakeProfileRepository>(new ContainerControlledLifetimeManager());

            _unitOfWork = Mock.Create<IUnitOfWork>();
        }

        [Test]
        public void Get_should_return_a_list_of_profiles()
        {
            //arrange
            var controller = new ProfileController(_unitOfWork);

            //act
            var list = controller.Get();

            //assert
            Assert.AreEqual(5, list.Count());
        }

        [Test]
        public void Get_should_return_one_profile()
        {
            //arrange
            const string gamerTag = "1";
            var controller = new ProfileController(_unitOfWork);
            
            //act
            var p = controller.Get(gamerTag);

            //assert
            Assert.AreEqual(gamerTag, p.GamerTag);
        }

        [Test]
        public void Put_should_update_a_profile()
        {
            //arrange
            const string gamerTag = "1";
            const string game = "game";
            const string console = "console";
            var controller = new ProfileController(_unitOfWork);
            Mock.Arrange(()  => _unitOfWork.Commit()).MustBeCalled();


            //act
            var p = controller.Put(Profile.Create(gamerTag, game, console));

            //assert
            Assert.AreEqual(gamerTag, p.GamerTag);
            Assert.AreEqual(game, p.Game);
            Assert.AreEqual(console, p.Console);
            Mock.Assert(_unitOfWork);

        }

        [Test]
        public void Post_should_add_a_profile()
        {
            //arrange
            const string gamerTag = "10";
            const string game = "game";
            const string console = "console";
            var controller = new ProfileController(_unitOfWork);
            Mock.Arrange(()  => _unitOfWork.Commit()).MustBeCalled();

            //act
            controller.Post(Profile.Create(gamerTag, game, console));

            //assert
            var list = controller.Get();
            Assert.AreEqual(6, list.Count());
            Mock.Assert(_unitOfWork);
        }

        [TearDown]
        public void TearDown()
        {
        }

        #region Repo

        public class FakeProfileRepository : IProfileRepository
        {
            private readonly List<Profile> _profiles;

            public FakeProfileRepository()
            {
                _profiles = new List<Profile>
                {
                    Profile.Create("1", "1", "1"),
                    Profile.Create("2", "1", "1"),
                    Profile.Create("3", "1", "1"),
                    Profile.Create("4", "1", "1"),
                    Profile.Create("5", "1", "1"),
                };
            }

            public IQueryable<Profile> GetAll()
            {
                return _profiles.AsQueryable();
            }

            public IEnumerable<Profile> Find(Expression<Func<Profile, bool>> @where)
            {
                return _profiles.AsQueryable().Where(where);
            }

            public Profile First(Expression<Func<Profile, bool>> @where)
            {
                return _profiles.AsQueryable().First(where);
            }

            public Profile First()
            {
                return _profiles.FirstOrDefault();
            }

            public void Delete(Profile entity)
            {
                _profiles.Remove(entity);
            }

            public void Add(Profile entity)
            {
                _profiles.Add(entity);
            }

            public Profile GetByGamerTag(string gamerTag)
            {
                return First(p => p.GamerTag.Equals(gamerTag));
            }
        }

        #endregion

        
    }
}
