using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using PEW.Web.Api.Models;

namespace PEW.Tests.Models
{
    [TestFixture]
    public class MatchModelTests
    {

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void MatchModel_should_handle_parsing_of_non_existing_final_score()
        {
            var match = new Match();
            Assert.AreEqual(0, match.GoalsFor);
            Assert.AreEqual(0, match.GoalsAgainst);
        }

        [Test]
        public void MatchModel_should_handle_parsing_of_missing_golas_separator_on_final_score()
        {
            var match = new Match();
            match.FinalScore = "1";
            Assert.AreEqual(0, match.GoalsFor);
            Assert.AreEqual(0, match.GoalsAgainst);
        }

        [Test]
        public void MatchModel_should_handle_parsing_of_non_integer_on_final_score()
        {
            var match = new Match();
            match.FinalScore = "q-e";
            Assert.AreEqual(0, match.GoalsFor);
            Assert.AreEqual(0, match.GoalsAgainst);
        }

        [Test]
        public void MatchModel_should_handle_parsing_of_non_integer_with_spacing_on_final_score()
        {
            var match = new Match();
            match.FinalScore = " q - e";
            Assert.AreEqual(0, match.GoalsFor);
            Assert.AreEqual(0, match.GoalsAgainst);
        }

        [Test]
        public void MatchModel_should_handle_parsing_of_well_formed_final_score()
        {
            var match = new Match();
            match.FinalScore = "10-20";
            Assert.AreEqual(10, match.GoalsFor);
            Assert.AreEqual(20, match.GoalsAgainst);
        }

        [Test]
        public void MatchModel_should_handle_parsing_of_spacing_on_final_score()
        {
            var match = new Match();
            match.FinalScore = " 10 - 20 ";
            Assert.AreEqual(10, match.GoalsFor);
            Assert.AreEqual(20, match.GoalsAgainst);
        }

        [TearDown]
        public void Teardown()
        {

        }
    }
}
