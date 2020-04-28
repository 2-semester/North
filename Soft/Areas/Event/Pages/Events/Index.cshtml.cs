using System.Threading.Tasks;
using North.Domain.Event;
using North.Pages.Event;

namespace North.Soft.Areas.Event.Pages.Events
{
    public class IndexModel : EventsPage
    {
        public IndexModel(IEventsRepository r) : base(r)
        {
        }

        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex,string fixedFilter,string fixedValue)
        {
            await getList(sortOrder, currentFilter, searchString, pageIndex,fixedFilter,fixedValue );
        }
    }
}
