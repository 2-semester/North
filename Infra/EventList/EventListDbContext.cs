using Microsoft.EntityFrameworkCore;
using North.Data.EventList;

namespace North.Infra.EventList
{
    public class EventListDbContext : DbContext
    {
        public DbSet<EventListData> EventLists { get; set; }

        public EventListDbContext(DbContextOptions<EventListDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            InitializeTables(builder);
        }
        public static void InitializeTables(ModelBuilder builder)
        {
            if (builder is null) return;
            builder.Entity<EventListData>().ToTable(nameof(EventLists));
        }
    }
}
