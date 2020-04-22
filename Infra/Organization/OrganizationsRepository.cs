using North.Data.Organization;
using North.Domain.Organization;

namespace North.Infra.Organization
{
    public sealed class OrganizationsRepository : UniqueEntityRepository<OrganizationDomain, OrganizationData>, IOrganizationsRepository
    {
        public OrganizationsRepository(OrganizationDbContext c) : base(c, c.Organizations) { }

        protected internal override OrganizationDomain toDomainObject(OrganizationData d) => new OrganizationDomain(d);
    }
}
