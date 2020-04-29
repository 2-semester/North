using System.Threading.Tasks;
using North.Domain.Event;
using North.Domain.SportCategory;
using North.Pages.Event;

namespace North.Soft.Areas.Event.Pages.Events
{
    public class IndexModel : EventsPage
    {
        public IndexModel(IEventsRepository r, ISportCategoriesRepository m) : base(r, m) { }

        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex,string fixedFilter,string fixedValue)
        {
            await getList(sortOrder, currentFilter, searchString, pageIndex,fixedFilter,fixedValue );
        }
    }
}
