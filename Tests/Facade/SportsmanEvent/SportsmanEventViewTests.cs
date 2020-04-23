using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Facade.Common;
using North.Facade.SportsmanEvent;

namespace North.Tests.Facade.SportsmanEvent
{
    [TestClass]
    public class SportsmanEventViewTests:SealedClassTests<SportsmanEventView, UniqueEntityView>
    {
        [TestMethod]
        public void SportsmanIdTest() => isNullableProperty(() => obj.SportsmanId, x => obj.SportsmanId = x);
        
        [TestMethod]
        public void EventIdTest() => isNullableProperty(() => obj.EventId, x => obj.EventId = x);

        [TestMethod]
        public void GetIdTest()
        {
            var actual = obj.GetId();
            var expected = $"{obj.SportsmanId}.{obj.EventId}";
            Assert.AreEqual(expected, actual);
        }
    }
}
