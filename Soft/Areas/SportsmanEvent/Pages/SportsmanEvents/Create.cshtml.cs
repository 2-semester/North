using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using North.Domain.Event;
using North.Domain.Sportsman;
using North.Domain.SportsmanEvent;
using North.Pages.SportsmanEvent;

namespace North.Soft.Areas.SportsmanEvent.Pages.SportsmanEvents
{
    public class CreateModel : SportsmanEventsPage
    {
        public CreateModel(ISportsmanEventsRepository r,ISportsmenRepository m, IEventsRepository e) : base(r, m,e) {}
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
