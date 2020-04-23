using North.Data.Organization;
using North.Domain.Organization;
using North.Facade.Organization;

namespace North.Pages.Organization
{
    public class OrganizationsPage : CommonPage<IOrganizationsRepository, OrganizationDomain,
        OrganizationView, OrganizationData>
    {
        protected internal OrganizationsPage(IOrganizationsRepository r) : base(r)
        {
            PageTitle = "Organisatsioonid";
        }

        public override string ItemId => Item?.Id ?? string.Empty;

        protected internal override string getPageUrl() => "/Organization/Organizations";

        protected internal override OrganizationDomain toObject(OrganizationView view)
        {
            return OrganizationViewFactory.Create(view);
        }

        protected internal override OrganizationView toView(OrganizationDomain obj)
        {
            return OrganizationViewFactory.Create(obj);
        }
    }
}
