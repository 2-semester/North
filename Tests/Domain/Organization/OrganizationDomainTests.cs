using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Data.Common;
using North.Data.Organization;
using North.Domain.Common;
using North.Domain.Organization;

namespace North.Tests.Domain.Organization
{
    [TestClass]
    public class OrganizationDomainTests: SealedClassTests<OrganizationDomain,Entity<OrganizationData>> { }
}
