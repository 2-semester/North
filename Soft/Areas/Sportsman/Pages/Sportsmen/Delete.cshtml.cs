using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using North.Domain.Sportsman;
using North.Pages.Sportsman;

namespace North.Soft.Areas.Sportsman.Pages.Sportsmen
{
    public class DeleteModel : SportsmenPage
    {
        public DeleteModel(ISportsmenRepository r) : base(r) { }
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
