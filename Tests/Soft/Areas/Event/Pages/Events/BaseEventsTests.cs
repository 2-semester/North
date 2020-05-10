using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using North.Aids.Random;
using North.Data.Event;
using North.Facade.Event;

namespace North.Tests.Soft.Areas.Event.Pages.Events
{

    public abstract class BaseEventsTests : BaseNorthTests<EventView, EventData>
    {

        protected override string baseUrl() => "/Event/Events";

        protected override string itemId(EventData d) => d.Id;

        protected override void setId(EventData d, string id) => d.Id = id;

        protected override async Task addRelatedItems(EventData d) => await Task.CompletedTask;

        protected override void changeValuesExceptId(EventData d)
        {
            var id = d.Id;
            d = GetRandom.Object<EventData>();
            d.Id = id;
        }

        protected override IEnumerable<Expression<Func<EventView, object>>> indexPageColumns =>
            new Expression<Func<EventView, object>>[] {
                x => x.Id,
                x => x.Name,
                x => x.Definition,
                x => x.ValidFrom,
                x => x.ValidTo
            };

        protected override void dataInDetailsPage()
        {
            canView(item, m => m.TypeId);
            canView(item, m => m.OrganizationId);
            canView(item, m => m.EventListId);
            canView(item, m => m.Id);
            canView(item, m => m.Name);
            canView(item, m => m.SportCategoryId);
            canView(item, m => m.Definition);
        }
        protected override void dataInEditPage()
        {
            canEdit(item, m => m.SportCategoryId);
            canEdit(item, m => m.TypeId, true);
            canEdit(item, m => m.OrganizationId);
            canEdit(item, m => m.EventListId);
            canEdit(item, m => m.LocationId);
            canEdit(item, m => m.Name);
            canEdit(item, m => m.EventDate);
            canEdit(item, m => m.Definition);
        }

        protected override void dataInCreatePage()
        {
            canEdit(null, m => m.SportCategoryId, true);
            canEdit(null, m => m.TypeId);
            canEdit(null, m => m.OrganizationId, true);
            canEdit(null, m => m.EventListId);
            canEdit(null, m => m.LocationId);
            canEdit(null, m => m.Name);
            canEdit(null, m => m.Id);
            canEdit(null, m => m.EventDate);
            canEdit(null, m => m.Definition);
        }
    }

}
