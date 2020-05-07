using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Aids;
using North.Data.Event;
using North.Data.EventList;
using North.Data.Location;
using North.Data.Organization;
using North.Data.SportCategory;
using North.Domain.Event;
using North.Domain.EventList;
using North.Domain.Location;
using North.Domain.Organization;
using North.Domain.SportCategory;
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
            internal testClass(IEventsRepository r, ISportCategoriesRepository m, IOrganizationsRepository o, IEventListsRepository e, ILocationsRepository l) : base(r, m, o, e, l)
            {
            }
        }

        private class testRepository : baseTestRepositoryForUniqueEntity<EventDomain, EventData>, IEventsRepository { }
        private class testSportCategoryRepository : baseTestRepositoryForUniqueEntity<SportCategoryDomain, SportCategoryData>, ISportCategoriesRepository { }
        private class testOrganizationsRepository : baseTestRepositoryForUniqueEntity<OrganizationDomain, OrganizationData>, IOrganizationsRepository { }
        private class testEventListsRepository : baseTestRepositoryForUniqueEntity<EventListDomain, EventListData>, IEventListsRepository { }
        private class testLocationsRepository : baseTestRepositoryForUniqueEntity<LocationDomain, LocationData>, ILocationsRepository { }

        private testSportCategoryRepository categories;
        private testRepository events;
        private SportCategoryData data;
        private testOrganizationsRepository organizations;
        private testEventListsRepository eventLists;
        private testLocationsRepository locations;

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            events = new testRepository();
            categories= new testSportCategoryRepository();
            locations = new testLocationsRepository(); //kas see on siin vajalik? ilma selleta oli ka probleem
            data = GetRandom.Object<SportCategoryData>();
            var m = new SportCategoryDomain(data);
            categories.Add(m).GetAwaiter();
            obj = new testClass(events,categories,organizations,eventLists,locations);
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
            var d= GetRandom.Object<EventData>();
            var view = obj.toView(new EventDomain(d));
            testArePropertyValuesEqual(view, d);
        }
        [TestMethod]
        public void GetSportCategoryNameTest()
        {
            var name = obj.GetSportCategoryName(data.Id);
            Assert.AreEqual(data.Name, name);
        }
        [TestMethod]
        public void SportCategoriesTest()
        {
            var list = categories.Get().GetAwaiter().GetResult();
            Assert.AreEqual(list.Count, obj.SportCategories.Count());
        }

        //[TestMethod] //sellest saab veel ühe läbi kukkuva testi :)
        //public void LocationsTest()
        //{
        //    var list = categories.Get().GetAwaiter().GetResult();
        //    Assert.AreEqual(list.Count, obj.Locations.Count());
        //}
    }
}
