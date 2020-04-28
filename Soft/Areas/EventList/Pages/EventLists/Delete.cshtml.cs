using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using North.Domain.EventList;
using North.Pages.EventList;

namespace North.Soft.Areas.EventList.Pages.EventLists
{
    public class DeleteModel : EventListsPage
    {
        public DeleteModel(IEventListsRepository r) : base(r) { }
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
