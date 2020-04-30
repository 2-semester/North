using System.Threading.Tasks;
using North.Domain.Event;
using North.Domain.Sportsman;
using North.Domain.SportsmanEvent;
using North.Pages.SportsmanEvent;

namespace North.Soft.Areas.SportsmanEvent.Pages.SportsmanEvents
{
    public class IndexModel : SportsmanEventsPage

    { 
        public IndexModel(ISportsmanEventsRepository r, ISportsmenRepository m, IEventsRepository e) : base(r, m, e) { }

        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex,string fixedFilter,string fixedValue)
        {
            await getList(sortOrder, currentFilter, searchString, pageIndex,fixedFilter,fixedValue );
        }
    }
}
