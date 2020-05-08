using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using North.Domain.Event;
using North.Domain.EventList;
using North.Domain.Location;
using North.Domain.Organization;
using North.Domain.SportCategory;
using North.Pages.Event;

namespace North.Soft.Areas.Event.Pages.Events
{
    public class DetailsModel : EventsPage
    {
        public DetailsModel(IEventsRepository r, ISportCategoriesRepository m, IOrganizationsRepository o, IEventListsRepository e, ILocationsRepository l) : base(r, m, o, e, l) { }
        public async Task<IActionResult> OnGetAsync(string id, string fixedFilter, string fixedValue)
        {

            await getObject(id,fixedValue,fixedValue);
            return Page();
        }
    }
}

