using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using PEW.Core.Domain;
using PEW.Core.Exceptions;
using PEW.Core.Interfaces.Data;
using PEW.Core.Validation;
using PEW.Handlers;
using Telerik.JustMock;

namespace PEW.Tests.Handlers
{
    [TestFixture]
    public class ProfileHandlerTests
    {
        private IProfileRepository _profileRepository;

        [SetUp]
        public void Setup()
        {
            _profileRepository = Mock.Create<IProfileRepository>();
        }

        [Test]
        public void GetProfileByGamerTag_should_retrieve_a_profile()
        {
            //arrange
            const string gamerTag = "kalle_kula";
            var profile = Profile.Create(gamerTag, "nhl-13", "ps3");
            Mock.Arrange(() => _profileRepository.GetByGamerTag(gamerTag))
                .Returns(profile);
            
            //act
            var handler = new GetProfileByGamerTag(_profileRepository);
            var p = handler.Execute(gamerTag);
            
            //assert
            Assert.AreEqual(profile.GamerTag,  p.GamerTag);
            Assert.AreEqual(profile.Game, p.Game);
            Assert.AreEqual(profile.Console, p.Console);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddProfile_should_throw_exception_when_profile_is_null()
        {
            //arrange
            Profile profile = null;
            Mock.Arrange(() => _profileRepository.Add(profile))
                .IgnoreArguments();

            //act
            var handler = new AddProfile(_profileRepository, new Validator());
            handler.Execute(null);
        }

        [Test]
        [ExpectedException(typeof(ValidationException))]
        public void AddProfile_should_throw_exception_when_profile_is_invalid()
        {
            //arrange
            var profile = new Profile();
            Mock.Arrange(() => _profileRepository.Add(profile))
                .IgnoreArguments();

            //act
            var handler = new AddProfile(_profileRepository, new Validator());
            handler.Execute(profile);
        }

        [Test]
        public void AddProfile_should_should_add_when_profile_is_valid()
        {
            //arrange
            var profile = Profile.Create("kalle_kula", "nhl-13", "ps3");
            Mock.Arrange(() => _profileRepository.Add(profile))
                .IgnoreArguments()
                .MustBeCalled();

            //act
            var handler = new AddProfile(_profileRepository, new Validator());
            handler.Execute(profile);
        }

        [Test]
        [ExpectedException(typeof(ValidationException))]
        public void UpdateProfile_should_throw_exception_when_profile_is_invalid()
        {
            //arrange
            var profile = new Profile();
            Mock.Arrange(() => _profileRepository.Add(profile))
                .IgnoreArguments();

            //act
            var handler = new AddProfile(_profileRepository, new Validator());
            handler.Execute(profile);
        }

        [Test]
        public void UpdateProfile_should_should_update_when_profile_is_valid()
        {
            //arrange
            var p1 = Profile.Create("kalle_kula", "nhl-13", "ps3");
            var p2 = Profile.Create("kalle_kula", "nhl-12", "ps3");
            Mock.Arrange(() => _profileRepository.GetByGamerTag(p1.GamerTag))
                .Returns(p1)
                .MustBeCalled();

            //act
            var handler = new UpdateProfile(_profileRepository, new Validator());
            handler.Execute(p2);

            //assert
            Assert.AreEqual(p2.Game, p1.Game);
        }

        [TearDown]
        public void Teardown()
        {

        }
    }
}
