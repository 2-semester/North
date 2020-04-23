using System.Collections.Generic;

namespace North.Core.Organization
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
