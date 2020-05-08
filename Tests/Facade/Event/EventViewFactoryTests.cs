using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Aids;
using North.Data.Event;
using North.Domain.Event;
using North.Facade.Event;
using North.Tests.Aids;

namespace North.Tests.Facade.Event
{
    [TestClass]
    public class EventViewFactoryTests : BaseTests
    {
        [TestInitialize]
        public virtual void TestInitialize()
        {
            type = typeof(EventViewFactory);
        }

        [TestMethod]
        public void CreateTest() { }

        [TestMethod]
        public void CreateObjectTest()
        {
            var view = GetRandom.Object<EventView>();
            var data = EventViewFactory.Create(view).Data;

            testArePropertyValuesEqual(view, data);
        }

        [TestMethod]
        public void CreateViewTest()
        {
            var data = GetRandom.Object<EventData>();
            var view = EventViewFactory.Create(new EventDomain(data));

            testArePropertyValuesEqual(view, data);
        }
    }
}
