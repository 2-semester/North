using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Aids;
using North.Data.SportsmanEvent;
using North.Domain.SportsmanEvent;
using North.Facade.SportsmanEvent;

namespace North.Tests.Facade.SportsmanEvent
{
    [TestClass]
   public class SportsmanEventViewFactoryTests : BaseTests
    {
        [TestInitialize]
        public virtual void TestInitialize()
        {
            type = typeof(SportsmanEventViewFactory);
        }

        [TestMethod]
        public void CreateTest() { }

        [TestMethod]
        public void CreateObjectTest()
        {
            var view = GetRandom.Object<SportsmanEventView>();
            var data = SportsmanEventViewFactory.Create(view).Data;

            testArePropertyValuesEqual(view, data);
        }
        [TestMethod]
        public void CreateViewTest()
        {
            var data = GetRandom.Object<SportsmanEventData>();
            var view = SportsmanEventViewFactory.Create(new SportsmanEventDomain(data));

            testArePropertyValuesEqual(view, data);
        }
    }
}
