using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using North.Domain.Organization;
using North.Pages.Organization;

namespace North.Soft.Areas.Organization.Pages.Organizations
{
    public class CreateModel : OrganizationsPage
    {
        public CreateModel(IOrganizationsRepository r) : base(r) {}
        public IActionResult OnGet(string fixedFilter, string fixedValue)
        {
            FixedFilter = fixedFilter;
            FixedValue = fixedValue;
            return Page();
        }
       
        public async Task<IActionResult> OnPostAsync(string fixedFilter, string fixedValue)
        {
            if (!await addObject(fixedFilter, fixedValue)) return Page();
            return Redirect(IndexUrl);
        }
    }
}
