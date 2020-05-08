using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Aids;
using North.Aids.Random;
using North.Data.Event;

namespace North.Tests.Aids
{
    [TestClass]
    public class CopyTests : BaseTests
    {

        [TestInitialize]
        public void TestInitialize()
        {
            type = typeof(Copy);
        }

        [TestMethod]
        public void MembersTest()
        {
            var x = GetRandom.Object<EventData>();
            var y = GetRandom.Object<EventData>();
            testArePropertiesNotEqual(x, y);
            Copy.Members(x, y);
            testArePropertyValuesEqual(x, y);
        }
    }
}
