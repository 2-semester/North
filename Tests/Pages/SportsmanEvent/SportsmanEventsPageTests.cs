using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Aids.Random;
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
        private class testSportmenRepository : baseTestRepositoryForUniqueEntity<SportsmanDomain, SportsmanData>, ISportsmenRepository { }
        private class testEventRepository : baseTestRepositoryForUniqueEntity<EventDomain, EventData>, IEventsRepository { }
        private class testSportsmanEventsRepository : baseTestRepositoryForPeriodEntity<SportsmanEventDomain, SportsmanEventData>, ISportsmanEventsRepository {
            protected override bool isThis(SportsmanEventDomain entity, string id)
            {
                return true;
            }

            protected override string getId(SportsmanEventDomain entity)
            {
                return string.Empty;
            }
        }

        private testSportmenRepository sportsmen;
        private testEventRepository events;
        private testSportsmanEventsRepository sportsmanEvents;
        private SportsmanData data;

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            sportsmanEvents = new testSportsmanEventsRepository();
            sportsmen = new testSportmenRepository();
            events = new testEventRepository();
            data = GetRandom.Object<SportsmanData>();
            var m = new SportsmanDomain(data);
            sportsmen.Add(m).GetAwaiter();
            obj = new testClass(sportsmanEvents,sportsmen,events);
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
        public void PageTitleTest() => Assert.AreEqual("Registreeringud", obj.PageTitle);

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
            var d = GetRandom.Object<SportsmanEventData>();
            var v = obj.toView(new SportsmanEventDomain(d));
            testArePropertyValuesEqual(v, d);
        }
        [TestMethod]
        public void SportsmenTest()
        {
            var list = sportsmen.Get().GetAwaiter().GetResult();
            Assert.AreEqual(list.Count, obj.Sportsmen.Count());
        }
        [TestMethod]
        public void EventsTest()
        {
            var list = events.Get().GetAwaiter().GetResult();
            Assert.AreEqual(list.Count, obj.Events.Count());
        }
        [TestMethod]
        public void GetSportsmanIdNameTest()
        {
            var name = obj.GetSportsmanIdName(data.Id);
            Assert.AreEqual(data.Name, name);
        }
    }
}
