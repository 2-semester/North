using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Aids;
using North.Data.Event;
using North.Data.Sportsman;
using North.Data.SportsmanEvent;
using North.Domain.Event;
using North.Domain.Sportsman;
using North.Domain.SportsmanEvent;
using North.Facade.SportsmanEvent;
using North.Pages;
using North.Pages.SportsmanEvent;

namespace North.Tests.Pages.SportsmanEvent
{
    [TestClass]
    public class SportsmanEventsPageTests : AbstractClassTests<SportsmanEventsPage,
        CommonPage<ISportsmanEventsRepository, SportsmanEventDomain, SportsmanEventView, SportsmanEventData>>
    {
        private class testClass : SportsmanEventsPage
        {
            internal testClass(ISportsmanEventsRepository r, ISportsmenRepository m, IEventsRepository e)  : base(r,m,e)
            {
            }
        }
        private class testSportmanRepository : baseTestRepositoryForUniqueEntity<SportsmanDomain, SportsmanData>, ISportsmenRepository { }
        private class testEventRepository : baseTestRepositoryForUniqueEntity<EventDomain, EventData>, IEventsRepository { }
        private class testRepository : baseTestRepositoryForPeriodEntity<SportsmanEventDomain, SportsmanEventData>, ISportsmanEventsRepository {
            protected override bool isThis(SportsmanEventDomain entity, string id)
            {
                return true;
            }

            protected override string getId(SportsmanEventDomain entity)
            {
                return string.Empty;
            }
        }

        private testSportmanRepository sportsman;
        private testEventRepository events;
        private testRepository sportsmanEvent;

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            sportsmanEvent = new testRepository();
            sportsman = new testSportmanRepository();
            events = new testEventRepository();
            obj = new testClass(sportsmanEvent,sportsman,events);
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
        [TestMethod]
        public void SportsmenTest()
        {
            var list = sportsman.Get().GetAwaiter().GetResult();
            Assert.AreEqual(list.Count, obj.Sportsmen.Count());
        }
        [TestMethod]
        public void EventsTest()
        {
            var list = events.Get().GetAwaiter().GetResult();
            Assert.AreEqual(list.Count, obj.Events.Count());
        }
    }
}
