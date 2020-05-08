using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Aids;

namespace North.Tests.Aids
{
    [TestClass]
    public  class SystemRegionInfoTests : BaseTests
    {
        [TestInitialize]
        public void TestInitialize()
        {
            type = typeof(SystemRegionInfo);
        }
        [TestMethod]
        public void IsCountryTest()
        {
            Assert.IsFalse(SystemRegionInfo.IsCountry(null));
            testEstonia();
            testWorld();
        }

        private static void testEstonia()
        {
            var r = new RegionInfo("et-EE");
            Assert.IsNotNull(r);
            Assert.IsTrue(SystemRegionInfo.IsCountry(r));
            Assert.AreEqual("Estonia", r.EnglishName);
        }

        private static void testWorld()
        {
            var r = new RegionInfo("001");
            Assert.IsNotNull(r);
            Assert.IsFalse(SystemRegionInfo.IsCountry(r));
            Assert.AreEqual("World", r.EnglishName);
        }
    }
}


