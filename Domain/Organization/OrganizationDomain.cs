using North.Data.Organization;
using North.Domain.Common;

namespace North.Domain.Organization
{
    public sealed class OrganizationDomain : Entity<OrganizationData>
    {
        public OrganizationDomain() : this(null) { }
        public OrganizationDomain(OrganizationData data) : base(data) { }
    }
}
