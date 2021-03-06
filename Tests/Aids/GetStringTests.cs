﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Aids;
using North.Aids.Random;

namespace North.Tests.Aids 
{
    [TestClass]
    public  class GetStringTests : BaseTests
    {
        [TestMethod]
        public void HeadTest()
        {
            static string str() => GetRandom.String();
            var x = GetRandom.String();
            Assert.AreEqual(x, (x + '.' + str() + '.' + str()).GetHead());
            Assert.AreEqual(string.Empty, ((string)null).GetHead());
        }

        [TestMethod]
        public void TailTest()
        {
            static string str() => GetRandom.String();
            var x = str() + '.' + str() + '.' + str();
            Assert.AreEqual(x, (str() + '.' + x).GetTail());
            Assert.AreEqual(string.Empty, ((string)null).GetTail());
        }

        [TestMethod]
        public void GetHeadTest()
        {
            static string str() => GetRandom.String();
            var x = GetRandom.String();
            Assert.AreEqual(x, (x + '.' + str() + '.' + str()).GetHead());
            Assert.AreEqual(string.Empty, ((string)null).GetHead());
        }

        [TestMethod]
        public void GetTailTest()
        {
            static string str() => GetRandom.String();
            var x = str() + '.' + str() + '.' + str();
            Assert.AreEqual(x, (str() + '.' + x).GetTail());
            Assert.AreEqual(string.Empty, ((string)null).GetTail());
        }
    }
}
