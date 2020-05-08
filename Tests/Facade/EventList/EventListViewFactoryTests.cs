using Abc.Aids.Random;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Aids;
using North.Data.EventList;
using North.Domain.EventList;
using North.Facade.EventList;
using North.Tests.Aids;

namespace North.Tests.Facade.EventList
{

[TestClass]
public class EventListViewFactoryTests : BaseTests
    {
        [TestInitialize]
        public virtual void TestInitialize()
        {
            type = typeof(EventListViewFactory);
        }

        [TestMethod]
        public void CreateTest() { }

        [TestMethod]
        public void CreateObjectTest()
        {
            var view = GetRandom.Object<EventListView>();
            var data = EventListViewFactory.Create(view).Data;

            testArePropertyValuesEqual(view, data);
        }
        [TestMethod]
        public void CreateViewTest()
        {
            var data = GetRandom.Object<EventListData>();
            var view = EventListViewFactory.Create(new EventListDomain(data));

            testArePropertyValuesEqual(view, data);
        }

    }
}
