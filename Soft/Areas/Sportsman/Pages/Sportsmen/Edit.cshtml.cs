﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using North.Domain.Sportsman;
using North.Pages.Sportsman;

namespace North.Soft.Areas.Sportsman.Pages.Sportsmen
{
    public class EditModel : SportsmenPage
    {
        public EditModel(ISportsmenRepository r) : base(r) { }
        public async Task<IActionResult> OnGetAsync(string id, string fixedFilter, string fixedValue)
        {
            await getObject(id,fixedFilter,fixedValue);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string fixedFilter, string fixedValue)
        {
            await updateObject(fixedFilter,fixedValue);
            return Redirect(IndexUrl);
        }
    }
}
