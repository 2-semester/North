using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using North.Data.Event;
using North.Data.Sportsman;
using North.Data.SportsmanEvent;
using North.Domain.Event;
using North.Domain.Sportsman;
using North.Domain.SportsmanEvent;
using North.Facade.SportsmanEvent;

namespace North.Pages.SportsmanEvent
{
    public abstract class SportsmanEventsPage : CommonPage<ISportsmanEventsRepository, SportsmanEventDomain,
        SportsmanEventView, SportsmanEventData>
    {
        protected internal SportsmanEventsPage(ISportsmanEventsRepository r, ISportsmenRepository m, IEventsRepository e) : base(r)
        {
            PageTitle = "Registreeringud";
            Sportsmen = createSelectList<SportsmanDomain, SportsmanData>(m);
            Events = createSelectList<EventDomain, EventData>(e);
        }

        public override string ItemId => Item is null ? string.Empty : Item.GetId();
        public IEnumerable<SelectListItem> Sportsmen { get; }
        public IEnumerable<SelectListItem> Events { get; }

        protected internal override string getPageUrl() => "/SportsmanEvent/SportsmanEvents";

        protected internal override SportsmanEventDomain toObject(SportsmanEventView view)
        {
            return SportsmanEventViewFactory.Create(view);
        }

        protected internal override SportsmanEventView toView(SportsmanEventDomain obj)
        {
            return SportsmanEventViewFactory.Create(obj);
        }

    }
}
