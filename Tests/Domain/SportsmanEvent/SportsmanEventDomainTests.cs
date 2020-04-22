using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Data.Common;
using North.Data.SportsmanEvent;
using North.Domain.Common;
using North.Domain.SportsmanEvent;

namespace North.Tests.Domain.SportsmanEvent
{
    [TestClass]
    public class SportsmanEventDomainTests :SealedClassTests<SportsmanEventDomain,Entity<SportsmanEventData>> { }
}
