using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using North.Domain.Event;
using North.Domain.Sportsman;
using North.Domain.SportsmanEvent;
using North.Pages.SportsmanEvent;

namespace North.Soft.Areas.SportsmanEvent.Pages.SportsmanEvents
{
    public class DeleteModel : SportsmanEventsPage
    {
        public DeleteModel(ISportsmanEventsRepository r, ISportsmenRepository m, IEventsRepository e) : base(r, m, e) { }
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
