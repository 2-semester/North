using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Data.Sportsman;
using North.Domain.Common;
using North.Domain.Sportsman;

namespace North.Tests.Domain.Sportsman
{
    [TestClass]
    public class SportsmanDomainTests: SealedClassTests<SportsmanDomain, Entity<SportsmanData>> { }
}
