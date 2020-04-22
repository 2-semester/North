using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Data.Common;
using North.Data.Event;
using North.Domain.Common;
using North.Domain.Event;

namespace North.Tests.Domain.Event
{
    [TestClass]
    public class EventDomainTests: SealedClassTests<EventDomain,Entity<EventData>> { }
}
