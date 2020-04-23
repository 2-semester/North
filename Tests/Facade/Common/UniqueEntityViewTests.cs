using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Facade.Common;

namespace North.Tests.Facade.Common
{
    [TestClass]
    public class UniqueEntityViewTests : AbstractClassTests<UniqueEntityView, object>
    {
        private class testClass : UniqueEntityView { }


        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            obj = new testClass();

        }
        [TestMethod]
        public void IdTest()
        {
            isNullableProperty(() => obj.Id, x => obj.Id = x);
        }
    }
}
