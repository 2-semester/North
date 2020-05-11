using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using North.Aids.Random;
using North.Data.SportsmanEvent;
using North.Facade.SportsmanEvent;

namespace North.Tests.Soft.Areas.SportsmanEvent.Pages.SportsmanEvents
{

    public abstract class BaseSportsmanEventsTests : BaseNorthTests<SportsmanEventView, SportsmanEventData>
    {

        protected override string baseUrl() => "/SportsmanEvent/SportsmanEvents";

        protected override string itemId(SportsmanEventData d) => d.EventId;

        protected override void setId(SportsmanEventData d, string id) => d.EventId = id;

        protected override async Task addRelatedItems(SportsmanEventData d) => await Task.CompletedTask;

        protected override void changeValuesExceptId(SportsmanEventData d)
        {
            var id = d.EventId;
            d = GetRandom.Object<SportsmanEventData>();
            d.EventId = id;
        }

        protected override IEnumerable<Expression<Func<SportsmanEventView, object>>> indexPageColumns =>
            new Expression<Func<SportsmanEventView, object>>[] {
                x => x.SportsmanId,
                x => x.EventId,
               
            };

        protected override void dataInDetailsPage()
        {
            canView(item, m => m.SportsmanId);
            canView(item, m => m.EventId);
        }
        protected override void dataInEditPage()
        {
            canEdit(item, m => m.SportsmanId);
            canEdit(item, m => m.EventId, true);
        }

        protected override void dataInCreatePage()
        {
            canEdit(null, m => m.SportsmanId, true);
            canEdit(null, m => m.EventId, true);
        }
    }

}
