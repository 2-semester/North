using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Aids;

namespace North.Tests.Aids {
    [TestClass]
    public class RegularExpressionTests : BaseTests
    {

        [TestInitialize] public void TestInitialize() => type = typeof(RegularExpressionFor);

        [TestMethod]
        public void CapitalsTest()
        {
            var match = RegularExpressionFor.EnglishCapitalsOnly;
            Assert.IsTrue(Regex.IsMatch("ABC", match));
            Assert.IsFalse(Regex.IsMatch("ABc", match));
            Assert.IsFalse(Regex.IsMatch("AB ", match));
            Assert.IsFalse(Regex.IsMatch("AB1", match));
        }

        [TestMethod]
        public void TextTest()
        {
            var match = RegularExpressionFor.EnglishTextOnly;
            Assert.IsTrue(Regex.IsMatch("ABC", match));
            Assert.IsTrue(Regex.IsMatch("ABc", match));
            Assert.IsTrue(Regex.IsMatch("AB ", match));
            Assert.IsTrue(Regex.IsMatch("AB'", match));
            Assert.IsTrue(Regex.IsMatch("AB\"", match));
            Assert.IsFalse(Regex.IsMatch("AB1", match));
            Assert.IsFalse(Regex.IsMatch("AB?", match));
            Assert.IsFalse(Regex.IsMatch("aBC", match));
        }

        [TestMethod]
        public void CapitalsAndNumbersTest()
        {
            var match = RegularExpressionFor.EnglishCapitalsAndNumbersOnly;
            Assert.IsTrue(Regex.IsMatch("ABC", match));
            Assert.IsFalse(Regex.IsMatch("ABc", match));
            Assert.IsFalse(Regex.IsMatch("AB ", match));
            Assert.IsFalse(Regex.IsMatch("AB'", match));
            Assert.IsFalse(Regex.IsMatch("AB\"", match));
            Assert.IsTrue(Regex.IsMatch("AB1", match));
            Assert.IsTrue(Regex.IsMatch("A12345", match));
            Assert.IsFalse(Regex.IsMatch("1AB", match));
            Assert.IsFalse(Regex.IsMatch("aBC", match));
        }
    }
}

