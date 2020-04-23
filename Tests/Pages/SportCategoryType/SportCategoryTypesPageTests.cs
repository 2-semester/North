using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Aids;
using North.Data.SportCategoryType;
using North.Domain.SportCategoryType;
using North.Facade.SportCategoryType;
using North.Pages;
using North.Pages.SportCategoryType;

namespace North.Tests.Pages.SportCategoryType
{
    [TestClass]
    public class SportCategoryTypesPageTests : AbstractClassTests<SportCategoryTypesPage,
        CommonPage<ISportCategoryTypesRepository, SportCategoryTypeDomain, SportCategoryTypeView, SportCategoryTypeData>>
    {
        private class testClass : SportCategoryTypesPage
        {
            internal testClass(ISportCategoryTypesRepository r) : base(r)
            {
            }
        }

        private class testRepository : baseTestRepositoryForUniqueEntity<SportCategoryTypeDomain, SportCategoryTypeData>, ISportCategoryTypesRepository { }

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
            var item = GetRandom.Object<SportCategoryTypeView>();
            obj.Item = item;
            Assert.AreEqual(item.Id, obj.ItemId);
            obj.Item = null;
            Assert.AreEqual(string.Empty, obj.ItemId);
        }

        [TestMethod]
        public void PageTitleTest() => Assert.AreEqual("Spordiala", obj.PageTitle);

        [TestMethod]
        public void PageUrlTest() => Assert.AreEqual("/SportCategoryType/SportCategoryTypes", obj.PageUrl);

        [TestMethod]
        public void ToObjectTest()
        {
            var view = GetRandom.Object<SportCategoryTypeView>();
            var o = obj.toObject(view);
            testArePropertyValuesEqual(view, o.Data);
        }

        [TestMethod]
        public void ToViewTest()
        {
            var data = GetRandom.Object<SportCategoryTypeData>();
            var view = obj.toView(new SportCategoryTypeDomain(data));
            testArePropertyValuesEqual(view, data);
        }
    }
}
