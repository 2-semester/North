using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using North.Domain.Organization;
using North.Pages.Organization;

namespace North.Soft.Areas.Organization.Pages.Organizations
{
    public class DeleteModel : OrganizationsPage
    {
        public DeleteModel(IOrganizationsRepository r) : base(r) { }
        public async Task<IActionResult> OnGetAsync(string id, string fixedFilter, string fixedValue)
        {
     
            await getObject(id, fixedFilter,fixedValue);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id, string fixedFilter, string fixedValue)
        {

            await deleteObject(id,fixedFilter,fixedValue);
            return Redirect(IndexUrl);
        }
    }
}
