using System.Threading.Tasks;
using North.Domain.EventList;
using North.Pages.EventList;

namespace North.Soft.Areas.EventList.Pages.EventLists
{
    public class IndexModel : EventListsPage
    {
        public IndexModel(IEventListsRepository r) : base(r)
        {
        }

        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex,string fixedFilter,string fixedValue)
        {
            await getList(sortOrder, currentFilter, searchString, pageIndex,fixedFilter,fixedValue );
        }
    }
}
