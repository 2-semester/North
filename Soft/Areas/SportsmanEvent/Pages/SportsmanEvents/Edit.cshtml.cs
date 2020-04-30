using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using North.Domain.Event;
using North.Domain.SportCategory;
using North.Domain.Sportsman;
using North.Domain.SportsmanEvent;
using North.Pages.Event;
using North.Pages.Sportsman;
using North.Pages.SportsmanEvent;

namespace North.Soft.Areas.SportsmanEvent.Pages.SportsmanEvents
{
    public class EditModel : SportsmanEventsPage

    {
        public EditModel(ISportsmanEventsRepository r, ISportsmenRepository m, IEventsRepository e) : base(r, m, e) {}
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
