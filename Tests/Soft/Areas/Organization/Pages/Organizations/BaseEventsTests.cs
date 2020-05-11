using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using North.Aids.Random;
using North.Data.Organization;
using North.Facade.Organization;

namespace North.Tests.Soft.Areas.Organization.Pages.Organizations
{

    public abstract class BaseOrganizationsTests : BaseNorthTests<OrganizationView, OrganizationData>
    {

        protected override string baseUrl() => "/Organization/Organizations";

        protected override string itemId(OrganizationData d) => d.Id;

        protected override void setId(OrganizationData d, string id) => d.Id = id;

        protected override async Task addRelatedItems(OrganizationData d) => await Task.CompletedTask;

        protected override void changeValuesExceptId(OrganizationData d)
        {
            var id = d.Id;
            d = GetRandom.Object<OrganizationData>();
            d.Id = id;
        }

        protected override IEnumerable<Expression<Func<OrganizationView, object>>> indexPageColumns =>
            new Expression<Func<OrganizationView, object>>[] {
                x => x.Id,
                x => x.Name,
                x => x.Definition,
                x => x.ValidFrom,
                x => x.ValidTo
            };

        protected override void dataInDetailsPage()
        {
           
            canView(item, m => m.Id);
            canView(item, m => m.Name);
            canView(item, m => m.Definition);
        }
        protected override void dataInEditPage()
        {
            canEdit(item, m => m.Id);
            canEdit(item, m => m.Name);
            canEdit(item, m => m.Definition);
        }

        protected override void dataInCreatePage()
        {
            canEdit(null, m => m.Name);
            canEdit(null, m => m.Id);
            canEdit(null, m => m.Definition);
        }
    }

}
