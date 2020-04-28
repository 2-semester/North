using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using North.Domain.Organization;
using North.Pages.Organization;

namespace North.Soft.Areas.Organization.Pages.Organizations
{
    public class DetailsModel : OrganizationsPage
    {
        public DetailsModel(IOrganizationsRepository r) : base(r) { }
        public async Task<IActionResult> OnGetAsync(string id, string fixedFilter, string fixedValue)
        {

            await getObject(id,fixedValue,fixedValue);
            return Page();
        }
    }
}

