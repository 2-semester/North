using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Aids.Random;
using North.Data.SportCategory;
using North.Domain.SportCategory;
using North.Facade.SportCategory;

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
            var view = GetRandom.Object<SportCategoryView>();
            var data = SportCategoryViewFactory.Create(view).Data;

            testArePropertyValuesEqual(view, data);
        }

        [TestMethod]
        public void CreateViewTest()
        {
            var data = GetRandom.Object<SportCategoryData>();
            var view = SportCategoryViewFactory.Create(new SportCategoryDomain(data));

            testArePropertyValuesEqual(view, data);
        }
    }
}