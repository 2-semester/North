using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using North.Domain.Event;
using North.Pages.Event;

namespace North.Soft.Areas.Event.Pages.Events
{
    public class DetailsModel : EventsPage
    {
        public DetailsModel(IEventsRepository r) : base(r) { }
        public async Task<IActionResult> OnGetAsync(string id, string fixedFilter, string fixedValue)
        {

            await getObject(id,fixedValue,fixedValue);
            return Page();
        }
    }
}

