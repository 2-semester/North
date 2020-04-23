using Microsoft.EntityFrameworkCore;
using North.Data.Event;

namespace North.Infra.Event
{
    public class EventDbContext: DbContext
    {
        public DbSet<EventData> Events { get; set; }

        public EventDbContext(DbContextOptions<EventDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            InitializeTables(builder);
        }
        public static void InitializeTables(ModelBuilder builder)
        {
            if (builder is null) return;
            builder.Entity<EventData>().ToTable(nameof(Events)).HasKey(x => new {x.SportsmanEventId,x.EventListId, x.OrganizationId, x.TypeId, x.SportCategoryId});
        }
    }
}
