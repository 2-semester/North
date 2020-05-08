using System.Globalization;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Aids;

namespace North.Tests.Aids {

    [TestClass]
    public class SystemCultureInfoTests : BaseTests
    {

        [TestInitialize]
        public void TestInitialize()
        {
            type = typeof(SystemCultureInfo);
        }
        [TestMethod]
        public void GetSpecificTest()
        {
            var expected =
                CultureInfo.GetCultures(CultureTypes.SpecificCultures);
            var actual = SystemCultureInfo.GetSpecificCultures();
            Assert.AreEqual(expected.Length, actual.Length);

            foreach (var a in actual)
            {
                if (expected.Contains(a)) continue;

                Assert.Fail("{0} is not in list", a);
            }
        }
        [TestMethod]
        public void GetCulturesTest()
        {
            var allCultures = CultureTypes.AllCultures;
            var expected = CultureInfo.GetCultures(allCultures);
            var actual = SystemCultureInfo.GetCultures(allCultures);
            Assert.AreEqual(expected.Length, actual.Length);

            foreach (var a in actual)
            {
                if (expected.Contains(a)) continue;

                Assert.Fail("{0} is not in list", a);
            }
        }

        [TestMethod]
        public void ToRegionInfoTest()
        {
            var culture = new CultureInfo("et-EE");
            var region = SystemCultureInfo.ToRegionInfo(culture);
            Assert.AreEqual("EST", region.ThreeLetterISORegionName);
            Assert.AreEqual("EE", region.TwoLetterISORegionName);
            Assert.AreEqual("Estonia", region.EnglishName);
        }

        [TestMethod]
        public void ToRegionInfoNullTest()
        {
            var r = SystemCultureInfo.ToRegionInfo(null);
            Assert.IsNull(r);
        }

        [TestMethod]
        public void WrongTypeTest()
        {
            var t = CultureTypes.UserCustomCulture &
                    CultureTypes.AllCultures;
            var c = SystemCultureInfo.GetCultures(t);
            Assert.IsNotNull(c);
            Assert.AreEqual(0, c.Length);
        }
    }
}







