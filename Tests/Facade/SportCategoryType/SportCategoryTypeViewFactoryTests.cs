using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Aids;
using North.Data.SportCategoryType;
using North.Domain.SportCategoryType;
using North.Facade.SportCategoryType;
using North.Tests.Aids;

namespace North.Tests.Facade.SportCategoryType
{
    [TestClass]
    public class SportCategoryTypeViewFactoryTests : BaseTests
    {
        [TestInitialize]
        public virtual void TestInitialize()
        {
            type = typeof(SportCategoryTypeViewFactory);
        }

        [TestMethod]
        public void CreateTest()
        {
        }

        [TestMethod]
        public void CreateObjectTest()
        {
            var view = GetRandomTests.Object<SportCategoryTypeView>();
            var data = SportCategoryTypeViewFactory.Create(view).Data;

            testArePropertyValuesEqual(view, data);
        }

        [TestMethod]
        public void CreateViewTest()
        {
            var data = GetRandomTests.Object<SportCategoryTypeData>();
            var view = SportCategoryTypeViewFactory.Create(new SportCategoryTypeDomain(data));

            testArePropertyValuesEqual(view, data);
        }
    }
}