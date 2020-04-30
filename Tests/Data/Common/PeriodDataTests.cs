using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Data.Common;

namespace North.Tests.Data.Common
{
    [TestClass]
    public class PeriodDataTests : AbstractClassTests<PeriodData, object>
    {
        private class testClass : PeriodData { }
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            obj = new testClass();
        }
        [TestMethod]
        public void ValidFromTest()
        {
            isNullableProperty(() => obj.ValidFrom, x => obj.ValidFrom = x);
        }
        [TestMethod]
        public void ValidToTest()
        {
            isNullableProperty(() => obj.ValidTo, x => obj.ValidTo = x);
        }
    }
}