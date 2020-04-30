using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Aids;
using North.Data.Event;
using North.Domain.Event;
using North.Facade.Event;
using North.Pages;

namespace North.Tests.Pages {

    [TestClass]
    public class CommonPageTests
        : AbstractPageTests<CommonPage<IEventsRepository, EventDomain, EventView, EventData>
            , PaginatedPage<IEventsRepository, EventDomain, EventView, EventData>> {
       
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            obj = new testClass(new testRepository());
        }

        [TestMethod] public void ItemIdTest() {
            obj.Item = GetRandom.Object<EventView>();
            Assert.AreEqual(obj.Item.GetId(), obj.ItemId);
        }

        [TestMethod] public void PageTitleTest() {
            isNullableProperty(()=> obj.PageTitle, x => obj.PageTitle = x);
        }

        [TestMethod] public void PageSubTitleTest() {
            isReadOnlyProperty(obj, nameof(obj.PageSubTitle), obj.getPageSubTitle());
        }

        [TestMethod] public void GetPageSubtitleTest() {
            Assert.AreEqual(obj.PageSubTitle, obj.getPageSubTitle());
        }

        [TestMethod] public void PageUrlTest() {
            isReadOnlyProperty(obj, nameof(obj.PageUrl), obj.getPageUrl());
        }

        [TestMethod] public void GetPageUrlTest() {
            Assert.AreEqual(obj.PageUrl, obj.getPageUrl());
        }

        [TestMethod] public void IndexUrlTest() {
            isReadOnlyProperty(obj, nameof(obj.IndexUrl), obj.getIndexUrl());
        }

        [TestMethod] public void GetIndexUrlTest() {
            Assert.AreEqual(obj.IndexUrl, obj.getIndexUrl());
        }

    }

}
