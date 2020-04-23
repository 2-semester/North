using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Data.Organization;
using North.Domain.Organization;
using North.Infra;
using North.Infra.Organization;

namespace North.Tests.Infra.Organization
{
    [TestClass]
    public class OrganizationsRepositoryTests : RepositoryTests<OrganizationsRepository, OrganizationDomain, OrganizationData>
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<OrganizationDbContext>()
                .UseInMemoryDatabase("TestDb")
                .Options;
            db = new OrganizationDbContext(options);
            dbSet = ((OrganizationDbContext)db).Organizations;
            obj = new OrganizationsRepository((OrganizationDbContext)db);
            base.TestInitialize();
        }

        protected override Type getBaseType()
        {
            return typeof(UniqueEntityRepository<OrganizationDomain, OrganizationData>);
        }

        protected override string getId(OrganizationData d) => d.Id;

        protected override OrganizationDomain getObject(OrganizationData d) => new OrganizationDomain(d);

        protected override void setId(OrganizationData d, string id) => d.Id = id;
    }
}
