using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using North.Domain.Sportsman;
using North.Pages.Sportsman;

namespace North.Soft.Areas.Sportsman.Pages.Sportsmen
{
    public class DetailsModel : SportsmenPage
    {
        public DetailsModel(ISportsmenRepository r) : base(r) { }
        public async Task<IActionResult> OnGetAsync(string id, string fixedFilter, string fixedValue)
        {
            await getObject(id,fixedValue,fixedValue);
            return Page();
        }
    }
}

