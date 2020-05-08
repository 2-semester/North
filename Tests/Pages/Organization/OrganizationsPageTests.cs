using Abc.Aids.Random;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Aids;
using North.Data.Organization;
using North.Domain.Organization;
using North.Facade.Organization;
using North.Pages;
using North.Pages.Organization;
using North.Tests.Aids;

namespace North.Tests.Pages.Organization
{
    [TestClass]
    public class OrganizationsPageTests : AbstractClassTests<OrganizationsPage,
        CommonPage<IOrganizationsRepository, OrganizationDomain, OrganizationView, OrganizationData>>
    {
        private class testClass : OrganizationsPage
        {
            internal testClass(IOrganizationsRepository r) : base(r)
            {
            }
        }

        private class testRepository : baseTestRepositoryForUniqueEntity<OrganizationDomain, OrganizationData>, IOrganizationsRepository { }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            var r = new testRepository();
            obj = new testClass(r);
        }

        [TestMethod]
        public void ItemIdTest()
        {
            var item = GetRandom.Object<OrganizationView>();
            obj.Item = item;
            Assert.AreEqual(item.Id, obj.ItemId);
            obj.Item = null;
            Assert.AreEqual(string.Empty, obj.ItemId);
        }

        [TestMethod]
        public void PageTitleTest() => Assert.AreEqual("Organisatsioonid", obj.PageTitle);

        [TestMethod]
        public void PageUrlTest() => Assert.AreEqual("/Organization/Organizations", obj.PageUrl);

        [TestMethod]
        public void ToObjectTest()
        {
            var view = GetRandom.Object<OrganizationView>();
            var o = obj.toObject(view);
            testArePropertyValuesEqual(view, o.Data);
        }

        [TestMethod]
        public void ToViewTest()
        {
            var data = GetRandom.Object<OrganizationData>();
            var view = obj.toView(new OrganizationDomain(data));
            testArePropertyValuesEqual(view, data);
        }
    }
}
