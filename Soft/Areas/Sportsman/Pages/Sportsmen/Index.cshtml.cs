using System.Threading.Tasks;
using North.Domain.Sportsman;
using North.Pages.Sportsman;

namespace North.Soft.Areas.Sportsman.Pages.Sportsmen
{
    public class IndexModel : SportsmenPage
    {
        public IndexModel(ISportsmenRepository r) : base(r)
        {
        }

        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex,string fixedFilter,string fixedValue)
        {
            await getList(sortOrder, currentFilter, searchString, pageIndex,fixedFilter,fixedValue );
        }
    }
}
