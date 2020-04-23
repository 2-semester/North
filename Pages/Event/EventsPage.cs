using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using North.Aids;
using North.Data.Event;
using North.Domain.Event;
using North.Facade.Common;
using North.Facade.Event;

namespace North.Pages.Event
{
    public class EventsPage : CommonPage<IEventsRepository, EventDomain,
        EventView, EventData>
    {
        protected internal EventsPage (IEventsRepository r,IEventsRepository e) : base(r)
        {
            PageTitle = "Üritused";
            //Events = createSelectList<EventDomain, EventData>(e);
        }
        public override string ItemId => Item is null ? string.Empty : Item.GetId();
        //protected internal override string getPageSubTitle()
        //{
        //    return FixedValue is null
        //        ? base.getPageSubTitle()
        //        : $"For {GetEventListName(FixedValue)}";
        //}
        //public string GetEventName(string eventId)
        //{
        //    foreach (var m in Events)
        //        if (m.Value == eventId)
        //            return m.Text;
        //    return "Unspecified";
        //}

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
