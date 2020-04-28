using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using North.Domain.EventList;
using North.Pages.EventList;

namespace North.Soft.Areas.EventList.Pages.EventLists
{
    public class CreateModel : EventListsPage
    {
        public CreateModel(IEventListsRepository r) : base(r) {}
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
