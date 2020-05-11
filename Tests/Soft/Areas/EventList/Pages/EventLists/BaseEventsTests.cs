using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using North.Aids.Random;
using North.Data.Event;
using North.Data.EventList;
using North.Facade.Event;
using North.Facade.EventList;

namespace North.Tests.Soft.Areas.EventList.Pages.EventLists
{

    public abstract class BaseEventListsTests : BaseNorthTests<EventListView, EventListData>
    {

        protected override string baseUrl() => "/EventList/EventLists";

        protected override string itemId(EventListData d) => d.Id;

        protected override void setId(EventListData d, string id) => d.Id = id;

        protected override async Task addRelatedItems(EventListData d) => await Task.CompletedTask;

        protected override void changeValuesExceptId(EventListData d)
        {
            var id = d.Id;
            d = GetRandom.Object<EventListData>();
            d.Id = id;
        }

        protected override IEnumerable<Expression<Func<EventListView, object>>> indexPageColumns =>
            new Expression<Func<EventListView, object>>[] {
                x => x.Id,
                x => x.Name,
                x => x.ValidFrom,
                x => x.ValidTo
            };

        protected override void dataInDetailsPage()
        {
            canView(item, m => m.Id);
            canView(item, m => m.Name);
            canView(item, m => m.ValidFrom);
            canView(item, m => m.ValidTo);
        }
        protected override void dataInEditPage()
        {
            canEdit(item, m => m.Id);
            canEdit(item, m => m.Name);
            canEdit(item, m => m.ValidFrom);
            canEdit(item, m => m.ValidTo);
        }

        protected override void dataInCreatePage()
        {
            canEdit(null, m => m.Name);
            canEdit(null, m => m.Id);
            canEdit(null, m => m.ValidFrom);
            canEdit(null, m => m.ValidTo);
        }
    }

}
