using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Aids;
using North.Data.Event;
using North.Domain.Event;
using North.Facade.Event;
using North.Pages;
using North.Pages.Event;

namespace North.Tests.Pages.Event
{
    [TestClass]
    public class EventsPageTests : AbstractClassTests<EventsPage,
        CommonPage<IEventsRepository, EventDomain, EventView, EventData>>
    {
        private class testClass : EventsPage
        {
            internal testClass(IEventsRepository r) : base(r)
            {
            }
        }

        private class testRepository : baseTestRepositoryForUniqueEntity<EventDomain, EventData>, IEventsRepository { }

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
            var item = GetRandom.Object<EventView>();
            obj.Item = item;
            Assert.AreEqual(item.GetId(), obj.ItemId);
            obj.Item = null;
            Assert.AreEqual(string.Empty, obj.ItemId);
        }

        [TestMethod]
        public void PageTitleTest() => Assert.AreEqual("Üritused", obj.PageTitle);

        [TestMethod]
        public void PageUrlTest() => Assert.AreEqual("/Event/Events", obj.PageUrl);

        [TestMethod]
        public void ToObjectTest()
        {
            var view = GetRandom.Object<EventView>();
            var o = obj.toObject(view);
            testArePropertyValuesEqual(view, o.Data);
        }

        [TestMethod]
        public void ToViewTest()
        {
            var data = GetRandom.Object<EventData>();
            var view = obj.toView(new EventDomain(data));
            testArePropertyValuesEqual(view, data);
        }
    }
}
