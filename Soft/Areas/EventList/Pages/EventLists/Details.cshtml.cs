using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using North.Domain.EventList;
using North.Pages.EventList;

namespace North.Soft.Areas.EventList.Pages.EventLists
{
    public class DetailsModel : EventListsPage
    {
        public DetailsModel(IEventListsRepository r) : base(r) { }
        public async Task<IActionResult> OnGetAsync(string id, string fixedFilter, string fixedValue)
        {

            await getObject(id,fixedValue,fixedValue);
            return Page();
        }
    }
}

