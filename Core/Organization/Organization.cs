using System.Collections.Generic;
using North.Core.Organization;

namespace North.Core.Info
{
    public static class Organization
    {
        public static OrganizationInfo Organisatsioon = new OrganizationInfo(
            "Sportland", "Sportland", "Tereteretere");

        public static List<OrganizationInfo> organisatsioooon =>
            new List<OrganizationInfo> {
                new OrganizationInfo(
                    "Candela", "cd", "Candela")
            };
    }
}
