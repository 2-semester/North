using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using North.Domain.Event;
using North.Domain.SportCategory;
using North.Pages.Event;

namespace North.Soft.Areas.Event.Pages.Events
{
    public class CreateModel : EventsPage
    {
        public CreateModel(IEventsRepository r, ISportCategoriesRepository m) : base(r,m) {}
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
