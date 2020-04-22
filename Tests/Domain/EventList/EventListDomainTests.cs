using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Data.Common;
using North.Data.EventList;
using North.Domain.Common;
using North.Domain.EventList;

namespace North.Tests.Domain.EventList
{
    [TestClass]
    public class EventListDomainTests : SealedClassTests<EventListDomain, Entity<EventListData>> { }
}
