using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Aids;
using North.Data.SportCategory;
using North.Domain.SportCategory;
using North.Facade.SportCategory;
using North.Tests.Aids;

namespace North.Tests.Facade.SportCategory
{
    [TestClass]
    public class SportCategoryViewFactoryTests : BaseTests
    {
        [TestInitialize]
        public virtual void TestInitialize()
        {
            type = typeof(SportCategoryViewFactory);
        }

        [TestMethod]
        public void CreateTest()
        {
        }

        [TestMethod]
        public void CreateObjectTest()
        {
            var view = GetRandomTests.Object<SportCategoryView>();
            var data = SportCategoryViewFactory.Create(view).Data;

            testArePropertyValuesEqual(view, data);
        }

        [TestMethod]
        public void CreateViewTest()
        {
            var data = GetRandomTests.Object<SportCategoryData>();
            var view = SportCategoryViewFactory.Create(new SportCategoryDomain(data));

            testArePropertyValuesEqual(view, data);
        }
    }
}