using North.Aids;
using North.Data.Organization;
using North.Domain.Organization;

namespace North.Facade.Organization
{
  public static class OrganizationViewFactory
    {
        public static OrganizationDomain Create(OrganizationView view)
        {
            var d = new OrganizationData();
            Copy.Members(view, d);
            return new OrganizationDomain(d);
        }

        public static OrganizationView Create(OrganizationDomain obj)
        {
            var v = new OrganizationView();
            Copy.Members(obj.Data, v);
            return v;
        }
    }
}
