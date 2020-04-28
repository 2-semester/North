using System.Threading.Tasks;
using North.Domain.Organization;
using North.Pages.Organization;

namespace North.Soft.Areas.Organization.Pages.Organizations
{
    public class IndexModel : OrganizationsPage
    {
        public IndexModel(IOrganizationsRepository r) : base(r)
        {
        }

        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex,string fixedFilter,string fixedValue)
        {
            await getList(sortOrder, currentFilter, searchString, pageIndex,fixedFilter,fixedValue );
        }
    }
}
