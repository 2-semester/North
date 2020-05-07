using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Facade.Common;
using North.Facade.Event;

namespace North.Tests.Facade.Event
{
    [TestClass]
    public class EventViewTests : SealedClassTests<EventView, DefinedView>
    {
        [TestMethod]
        public void EventDateTest() => isProperty(() => obj.EventDate, x => obj.EventDate = x);

        [TestMethod]
        public void SportCategoryIdTest() => isNullableProperty(() => obj.SportCategoryId, x => obj.SportCategoryId = x);

        [TestMethod]
        public void TypeIdTest() => isNullableProperty(() => obj.TypeId, x => obj.TypeId = x);

        [TestMethod]
        public void OrganizationIdTest() => isNullableProperty(() => obj.OrganizationId, x => obj.OrganizationId = x);

        [TestMethod]
        public void EventListIdTest() => isProperty(() => obj.EventListId, x => obj.EventListId = x);
        [TestMethod]
        public void LocationIdTest() => isProperty(() => obj.LocationId, x => obj.LocationId = x);

        [TestMethod]
        public void GetIdTest()
        {
            var actual = obj.GetId();
            var expected = $"{obj.EventListId}.{obj.OrganizationId}.{obj.TypeId}.{obj.SportCategoryId}.{obj.LocationId}";
            Assert.AreEqual(expected, actual);
        }
    }
}
