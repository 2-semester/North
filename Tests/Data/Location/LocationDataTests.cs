using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Data.Common;
using North.Data.Location;

namespace North.Tests.Data.Location
{
    [TestClass]
    public class LocationDataTests:SealedClassTests<LocationData,NamedEntityData>
    {
        [TestMethod]
        public void EventIdTest()
        {
            isNullableProperty(() => obj.EventId, x => obj.EventId = x);
        }
        [TestMethod]
        public void EventListIdTest()
        {
            isNullableProperty(() => obj.EventListId, x => obj.EventListId = x);
        }
        [TestMethod]
        public void CountyTest()
        {
            isNullableProperty(() => obj.County, x => obj.County = x);
        }
        [TestMethod]
        public void CityTest()
        {
            isNullableProperty(() => obj.City, x => obj.City = x);
        }
    }
}
