using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using North.Aids.Random;
using North.Data.Sportsman;
using North.Facade.Sportsman;

namespace North.Tests.Soft.Areas.Sportsman.Pages.Sportsmen
{

    public abstract class BaseSportsmenTests : BaseNorthTests<SportsmanView, SportsmanData>
    {

        protected override string baseUrl() => "/Event/Events";

        protected override string itemId(SportsmanData d) => d.Id;

        protected override void setId(SportsmanData d, string id) => d.Id = id;

        protected override async Task addRelatedItems(SportsmanData d) => await Task.CompletedTask;

        protected override void changeValuesExceptId(SportsmanData d)
        {
            var id = d.Id;
            d = GetRandom.Object<SportsmanData>();
            d.Id = id;
        }

        protected override IEnumerable<Expression<Func<SportsmanView, object>>> indexPageColumns =>
            new Expression<Func<SportsmanView, object>>[] {
                x => x.Id,
                x => x.Name,
                x => x.DateOfBirth
            };

        protected override void dataInDetailsPage()
        {
            canView(item, m => m.Name);
            canView(item, m => m.DateOfBirth);
        }
        protected override void dataInEditPage()
        {
         
            canEdit(item, m => m.Name);
            canEdit(item, m => m.DateOfBirth);
        }

        protected override void dataInCreatePage()
        {
            canEdit(null, m => m.Name);
            canEdit(null, m => m.Id);
            canEdit(null, m => m.DateOfBirth);
        }
    }

}
