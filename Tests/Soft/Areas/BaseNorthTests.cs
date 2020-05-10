using System.Threading.Tasks;
using Abc.Tests.Soft;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Aids.Random;
using North.Data.Common;
using North.Data.Event;
using North.Data.EventList;
using North.Data.Organization;
using North.Data.Sportsman;
using North.Infra;

namespace North.Tests.Soft.Areas
{
    public abstract class BaseNorthTests<TView, TData> : BaseAcceptanceTests<TView, TData, NorthDbContext>
        where TData : PeriodData
    {

        private NorthDbContext db;

        [TestCleanup]
        public async Task TestCleanup()
        {
            db = getContext<NorthDbContext>();
            await clear(db.Events);
            await clear(db.EventLists);
            await clear(db.Organizations);
            await clear(db.Sportsmen);
            await clear(db.SportsmanEvents);
        }

        private async Task clear<T>(DbSet<T> set) where T : class
        {
            var l = await set.ToListAsync();
            set.RemoveRange(l);
            await db.SaveChangesAsync();
        }

        protected async Task addEvent(string id)
        {
            var t = GetRandom.Object<EventData>();
            t.Id = id;
            await addToDatabase(t);
        }

        protected async Task addEventList(string id)
        {
            var t = GetRandom.Object<EventListData>();
            t.Id = id;
            await addToDatabase(t);
        }

        protected async Task addSportsman(string id)
        {
            var t = GetRandom.Object<SportsmanData>();
            t.Id = id;
            await addToDatabase(t);
        }
        protected async Task addOrganization (string id)
        {
            var t = GetRandom.Object<OrganizationData>();
            t.Id = id;
            await addToDatabase(t);
        }

    }

}
