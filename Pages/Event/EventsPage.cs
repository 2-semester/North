using System;
using System.Collections.Generic;
using System.Text;
using North.Data.Event;
using North.Domain.Event;
using North.Facade.Event;

namespace North.Pages.Event
{
    public class EventsPage : CommonPage<IEventsRepository, EventDomain,
        EventView, EventData>
    {
        protected internal EventsPage (IEventsRepository r) : base(r)
        {
            PageTitle = "Üritused";
        }

        public override string ItemId => Item.Id;

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
