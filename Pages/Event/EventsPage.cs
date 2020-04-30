using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using North.Data.Event;
using North.Data.SportCategory;
using North.Domain.Event;
using North.Domain.SportCategory;
using North.Facade.Event;

namespace North.Pages.Event
{
    public abstract class EventsPage : CommonPage<IEventsRepository, EventDomain,
        EventView, EventData>
    {
        protected internal EventsPage (IEventsRepository r,ISportCategoriesRepository m):base(r)
        {
            PageTitle = "Üritused";
            SportCategories = createSelectList<SportCategoryDomain, SportCategoryData>(m);
        }
        public override string ItemId => Item is null ? string.Empty : Item.GetId();
        //protected internal override string getPageSubTitle(
        //{
        //    return FixedValue is null
        //        ? base.getPageSubTitle()
        //        : $"For {GetEventListName(FixedValue)}";
        //}
        public IEnumerable<SelectListItem> SportCategories { get; }
        public string GetSportCategoryName(string sportCategoryId)
        {
            foreach (var m in SportCategories)
                if (m.Value == sportCategoryId)
                    return m.Text;
            return "Unspecified";
        }

        protected internal override string getPageUrl() => "/Event/Events";

        protected internal override EventDomain toObject(EventView view)
        {
            return EventViewFactory.Create(view);
        }

        protected internal override EventView toView(EventDomain obj)
        {
            return EventViewFactory.Create(obj);
        }
    }
}
