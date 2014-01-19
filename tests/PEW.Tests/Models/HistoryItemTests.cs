using NUnit.Framework;
using PEW.Core;
using PEW.Core.Domain;
using PEW.Web.Api.Models;

namespace PEW.Tests.Models
{
    [TestFixture]
    public class HistoryItemTests
    {
        [Test]
        public void HistoryItem_can_parse_integer_from_ea_as_teamname()
        {
            var hi = new HistoryItem(string.Empty, "[10]", string.Empty, "[11]", string.Empty, true, string.Empty, string.Empty);
            Assert.AreEqual(hi.MyTeam, ProjectConstants.Teams[9]);
            Assert.AreEqual(hi.OpposingTeam, ProjectConstants.Teams[10]);
        }

        [Test]
        public void HistoryItem_return_orginal_if_bad_format_on_teamname()
        {
            var hi = new HistoryItem(string.Empty, "0]", string.Empty, "[1", string.Empty, true, string.Empty, string.Empty);
            Assert.AreEqual(hi.MyTeam, "0]");
            Assert.AreEqual(hi.OpposingTeam, "[1");
        }

        [Test]
        public void HistoryItem_return_orginal_if_unknown_on_teamname()
        {
            var hi = new HistoryItem(string.Empty, "[30]", string.Empty, "[30]", string.Empty, true, string.Empty, string.Empty);
            Assert.AreEqual(hi.MyTeam, "[30]");
            Assert.AreEqual(hi.OpposingTeam, "[30]");
        }
    }
}