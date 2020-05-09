using Microsoft.VisualBasic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Aids;
using North.Aids.Random;
using North.Pages.Extensions;

namespace North.Tests.Aids {
    [TestClass]
    public class SystemStringTests :BaseTests
    {
        [TestMethod]
        public void StartsWithLetterTest()
        {
            //see alljärgnev  töötab, aga pole vist piisavalt ammendav:
            //var s = GetRandom.String();
            //Assert.AreEqual(true, s.StartsWithLetter());
            //Assert.AreEqual(true, null);

            Assert.Inconclusive();
        }
        [TestMethod]
        public void ToBackwardsTest()
        {
            var s = "987654321" + GetRandom.String();
            s = s.ToBackwards();
            Assert.IsTrue(s.EndsWith("123456789"));
            s = ((string)null).ToBackwards();
            Assert.AreEqual(string.Empty, s);
        }
    }
}












