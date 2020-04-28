﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using North.Domain.Event;
using North.Pages.Event;

namespace North.Soft.Areas.Event.Pages.Events
{
    public class EditModel : EventsPage
    {
        public EditModel(IEventsRepository r) : base(r) { }
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
