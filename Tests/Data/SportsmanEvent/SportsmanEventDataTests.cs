using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Data.Common;
using North.Data.SportsmanEvent;

namespace North.Tests.Data.SportsmanEvent
{
    [TestClass]
    public class SportsmanEventDataTests :SealedClassTests<SportsmanEventData,PeriodData>
    {
        [TestMethod]
        public void SportsmanIdTest()
        {
            isNullableProperty(() => obj.SportsmanId, x => obj.SportsmanId = x);
        }
        [TestMethod]
        public void EventIdTest()
        {
            isNullableProperty(() => obj.EventId, x => obj.EventId = x);
        }
    }
}
