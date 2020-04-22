using North.Data.Organization;
using North.Domain.Common;

namespace North.Domain.Organization
{
    public sealed class Organization : Entity<OrganizationData>
    {
        public Organization() : this(null) { }
        public Organization(OrganizationData data) : base(data) { }
    }
}
