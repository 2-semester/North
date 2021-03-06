﻿using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Aids;

namespace North.Tests.Aids {

    [TestClass]
    public class UseCultureTests : BaseTests
    {
        [TestInitialize] public void TestInitialize() => type = typeof(UseCulture);

        [TestMethod]
        public void CurrentTest()
        {
            var current = CultureInfo.CurrentCulture;
            Assert.AreEqual(current, UseCulture.Current);
        }

        [TestMethod]
        public void EnglishTest()
        {
            var current = new CultureInfo("en-GB");
            Assert.AreEqual(current, UseCulture.English);
        }

        [TestMethod]
        public void InvariantTest()
        {
            var current = new CultureInfo("");
            Assert.AreEqual(current, UseCulture.Invariant);
        }
    }
}