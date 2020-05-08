using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Aids;
using North.Data.Organization;
using North.Domain.Organization;
using North.Facade.Organization;
using North.Tests.Aids;

namespace North.Tests.Facade.Organization
{
    [TestClass]
    public class OrganizationViewFactoryTests : BaseTests
    {
        [TestInitialize]
        public virtual void TestInitialize()
        {
            type = typeof(OrganizationViewFactory);
        }

        [TestMethod]
        public void CreateTest()
        {
        }

        [TestMethod]
        public void CreateObjectTest()
        {
            var view = GetRandomTests.Object<OrganizationView>();
            var data = OrganizationViewFactory.Create(view).Data;

            testArePropertyValuesEqual(view, data);
        }

        [TestMethod]
        public void CreateViewTest()
        {
            var data = GetRandomTests.Object<OrganizationData>();
            var view = OrganizationViewFactory.Create(new OrganizationDomain(data));

            testArePropertyValuesEqual(view, data);
        }
    }
}