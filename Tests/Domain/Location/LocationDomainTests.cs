using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Data.Location;
using North.Domain.Common;
using North.Domain.Location;

namespace North.Tests.Domain.Location
{
    [TestClass]
    public class LocationDomainTests : SealedClassTests<LocationDomain, Entity<LocationData>> { }
}
