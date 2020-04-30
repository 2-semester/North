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
    public class DetailsModel : SportsmanEventsPage

    {
        public DetailsModel(ISportsmanEventsRepository r, ISportsmenRepository m, IEventsRepository e) : base(r, m, e) { }
        public async Task<IActionResult> OnGetAsync(string id, string fixedFilter, string fixedValue)
        {

            await getObject(id,fixedValue,fixedValue);
            return Page();
        }
    }
}

