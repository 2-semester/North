using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using North.Domain.Event;
using North.Domain.SportCategory;
using North.Domain.Sportsman;
using North.Pages.Event;
using North.Pages.Sportsman;

namespace North.Soft.Areas.Sportsman.Pages.Sportsmen
{
    public class CreateModel : SportsmenPage
    {
        public CreateModel(ISportsmenRepository r) : base(r) {}
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
