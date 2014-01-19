using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using PEW.Web.Api.App_Start;

namespace PEW.Tests.Models
{
    [TestFixture]
    public class AutoMapperTests
    {
        [TestCase(60, 1, 0, 0, 0)]
        [TestCase(1440, 0, 0, 0, 1)]
        [TestCase(525600, 0, 0, 0, 365)]
        [TestCase(864000, 0, 0, 0, 600)]
        public void ConvertMinutesToTimeString_should_return_a_correct_amout_of_hours_minuter_seconds(
            decimal minutes, 
            int expectedHrs, 
            int excpectedMin, 
            int expectedSec,
            int expectedDays)
        {
            var s = AutoMapperConfig.ConvertMinutesToTimeString(minutes);
            var excpeted = string.Format("{3} days, {0} hours, {1} minutes and {2} seconds", expectedHrs, excpectedMin, expectedSec, expectedDays);
            Assert.AreEqual(excpeted, s);
        }

        [Test]
        public void ConvertMinutesToTimeString_should_handle_overflow_exception()
        {

            var s = AutoMapperConfig.ConvertMinutesToTimeString((decimal)TimeSpan.MaxValue.TotalMinutes);
            var excpeted = "too much!";
            Assert.AreEqual(excpeted, s);
        }
    }
}
