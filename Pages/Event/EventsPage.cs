﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using North.Data.Event;
using North.Data.EventList;
using North.Data.Organization;
using North.Data.SportCategory;
using North.Domain.Event;
using North.Domain.EventList;
using North.Domain.Organization;
using North.Domain.SportCategory;
using North.Facade.Event;

namespace North.Pages.Event
{
    public abstract class EventsPage : CommonPage<IEventsRepository, EventDomain,
        EventView, EventData>
    {
        protected internal EventsPage (IEventsRepository r,ISportCategoriesRepository m, IOrganizationsRepository o, IEventListsRepository e):base(r)
        {
            PageTitle = "Üritused";
            SportCategories = createSelectList<SportCategoryDomain, SportCategoryData>(m);
            Organizations = createSelectList<OrganizationDomain, OrganizationData>(o);
            EventLists = createSelectList<EventListDomain, EventListData>(e);
        }
        public override string ItemId => Item is null ? string.Empty : Item.GetId();
        public IEnumerable<SelectListItem> SportCategories { get; }
        public IEnumerable<SelectListItem> Organizations { get; }
        public IEnumerable<SelectListItem> EventLists { get; }


        public string GetSportCategoryName(string sportCategoryId)
        {
            foreach (var m in SportCategories)
                if (m.Value == sportCategoryId)
                    return m.Text;
            return "Unspecified";
        }
        public string GetOrganizationName(string organizationId)
        {
            foreach (var m in Organizations)
                if (m.Value == organizationId)
                    return m.Text;
            return "Unspecified";
        }
        public string GetEventListName(string eventListId)
        {
            foreach (var m in EventLists)
                if (m.Value == eventListId)
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
