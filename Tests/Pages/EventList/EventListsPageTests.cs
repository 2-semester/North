using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Aids.Random;
using North.Data.EventList;
using North.Domain.EventList;
using North.Facade.EventList;
using North.Pages;
using North.Pages.EventList;

namespace North.Tests.Pages.EventList
{
    [TestClass]
    public class EventListsPageTests : AbstractClassTests<EventListsPage,
        CommonPage<IEventListsRepository, EventListDomain, EventListView, EventListData>>
    {
        private class testClass : EventListsPage
        {
            internal testClass(IEventListsRepository r) : base(r)
            {
            }
        }

        private class testRepository : baseTestRepositoryForUniqueEntity<EventListDomain, EventListData>, IEventListsRepository { }

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
            var item = GetRandom.Object<EventListView>();
            obj.Item = item;
            Assert.AreEqual(item.Id, obj.ItemId);
            obj.Item = null;
            Assert.AreEqual(string.Empty, obj.ItemId);
        }

        [TestMethod]
        public void PageTitleTest() => Assert.AreEqual("Ürituste sarjad", obj.PageTitle);

        [TestMethod]
        public void PageUrlTest() => Assert.AreEqual("/EventList/EventLists", obj.PageUrl);

        [TestMethod]
        public void ToObjectTest()
        {
            var view = GetRandom.Object<EventListView>();
            var o = obj.toObject(view);
            testArePropertyValuesEqual(view, o.Data);
        }

        [TestMethod]
        public void ToViewTest()
        {
            var data = GetRandom.Object<EventListData>();
            var view = obj.toView(new EventListDomain(data));
            testArePropertyValuesEqual(view, data);
        }
    }
}
