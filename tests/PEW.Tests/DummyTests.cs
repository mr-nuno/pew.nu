using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PEW.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void One_and_one_should_equal_two()
        {
            var a = 1;
            var b = 1;
            var sum = a + b;

            Assert.AreEqual(2, sum);
        }
    }
}
