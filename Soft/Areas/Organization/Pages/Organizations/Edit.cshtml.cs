using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using North.Domain.EventList;
using North.Domain.Organization;
using North.Pages.EventList;
using North.Pages.Organization;

namespace North.Soft.Areas.Organization.Pages.Organizations
{
    public class EditModel : OrganizationsPage
    {
        public EditModel(IOrganizationsRepository r) : base(r) { }
        public async Task<IActionResult> OnGetAsync(string id, string fixedFilter, string fixedValue)
        {
            await getObject(id,fixedFilter,fixedValue);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string fixedFilter, string fixedValue)
        {
            await updateObject(fixedFilter,fixedValue);
            return Redirect(IndexUrl);
        }
    }
}
