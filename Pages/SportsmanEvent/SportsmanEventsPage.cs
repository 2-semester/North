using System;
using System.Collections.Generic;
using System.Text;
using North.Data.SportsmanEvent;
using North.Domain.Event;
using North.Domain.SportsmanEvent;
using North.Facade.Event;
using North.Facade.SportsmanEvent;

namespace North.Pages.SportsmanEvent
{
    public class SportsmanEventsPage : CommonPage<ISportsmanEventsRepository, SportsmanEventDomain,
        SportsmanEventView, SportsmanEventData>
    {
        protected internal SportsmanEventsPage(ISportsmanEventsRepository r) : base(r)
        {
            PageTitle = "Sportlase üritused";
        }

        public override string ItemId => Item is null ? string.Empty : Item.GetId();

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
