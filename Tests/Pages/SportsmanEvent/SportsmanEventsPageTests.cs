using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Aids;
using North.Data.EventList;
using North.Data.SportsmanEvent;
using North.Domain.EventList;
using North.Domain.SportsmanEvent;
using North.Facade.EventList;
using North.Facade.SportsmanEvent;
using North.Pages;
using North.Pages.EventList;
using North.Pages.SportsmanEvent;

namespace North.Tests.Pages.SportsmanEvent
{
    [TestClass]
    public class SportsmanEventsPageTests : AbstractClassTests<SportsmanEventsPage,
        CommonPage<ISportsmanEventsRepository, SportsmanEventDomain, SportsmanEventView, SportsmanEventData>>
    {
        private class testClass : SportsmanEventsPage
        {
            internal testClass(ISportsmanEventsRepository r) : base(r)
            {
            }
        }

        private class testRepository : baseTestRepositoryForUniqueEntity<SportsmanEventDomain, SportsmanEventData>, ISportsmanEventsRepository { }

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
            var item = GetRandom.Object<SportsmanEventView>();
            obj.Item = item;
            Assert.AreEqual(item.GetId(), obj.ItemId);
            obj.Item = null;
            Assert.AreEqual(string.Empty, obj.ItemId);
        }

        [TestMethod]
        public void PageTitleTest() => Assert.AreEqual("Sportlase üritused", obj.PageTitle);

        [TestMethod]
        public void PageUrlTest() => Assert.AreEqual("/SportsmanEvent/SportsmanEvents", obj.PageUrl);

        [TestMethod]
        public void ToObjectTest()
        {
            var view = GetRandom.Object<SportsmanEventView>();
            var o = obj.toObject(view);
            testArePropertyValuesEqual(view, o.Data);
        }

        [TestMethod]
        public void ToViewTest()
        {
            var data = GetRandom.Object<SportsmanEventData>();
            var view = obj.toView(new SportsmanEventDomain(data));
            testArePropertyValuesEqual(view, data);
        }
    }
}
