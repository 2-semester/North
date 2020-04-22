using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Aids;
using North.Data.Organization;
using North.Domain.Common;
using North.Tests.Data.Organization;

namespace North.Tests.Domain.Common
{
    [TestClass]
    public class EntityTests :AbstractClassTests<Entity<OrganizationData>,object>
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            obj = new testClass();
        }
        private class testClass : Entity<OrganizationData>
        {
            public testClass(OrganizationData d =null) : base(d) { }
        }

        [TestMethod]
        public void DataTest()
        {
            var d = GetRandom.Object<OrganizationData>();
            Assert.AreNotSame(d,obj.Data);
            obj = new testClass(d);
            Assert.AreSame(d, obj.Data);

        }
        [TestMethod]
        public void DataIsNullTest()
        {
            var d = GetRandom.Object<OrganizationData>();
            Assert.IsNull(obj.Data);
            obj.Data = d;
            Assert.AreSame(d, obj.Data);
        }
        [TestMethod]
        public void CanSetNullDataTest()
        {
            obj.Data = null;
            Assert.IsNull(obj.Data);
        }
    }
}
