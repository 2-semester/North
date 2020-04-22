using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Data.Common;
using North.Data.EventList;

namespace North.Tests.Data.EventList
{
    [TestClass]
    public class EventListDataTests : SealedClassTests<EventListData,UniqueEntityData>
    {
        [TestMethod]
        public void EventIdTest()
        {
            isNullableProperty(() => obj.EventId, x => obj.EventId = x);
        }
    }
}
