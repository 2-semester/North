using Microsoft.EntityFrameworkCore;
using North.Data.Event;
using North.Data.EventList;
using North.Data.Location;
using North.Data.Organization;
using North.Data.SportCategory;
using North.Data.SportCategoryType;
using North.Data.Sportsman;
using North.Data.SportsmanEvent;

namespace North.Infra
{
    public class NorthDbContext: DbContext
    {
        public NorthDbContext(DbContextOptions<NorthDbContext> options)
            : base(options) { }

        public DbSet<EventData> Events { get; set; }
        public DbSet<EventListData> EventLists { get; set; }
        public DbSet<LocationData> Locations { get; set; }
        public DbSet<OrganizationData> Organizations { get; set; }
        public DbSet<SportCategoryData> SportCategories { get; set; }
        public DbSet<SportCategoryTypeData> SportCategoryTypes { get; set; }
        public DbSet<SportsmanData> Sportsmen { get; set; }
        public DbSet<SportsmanEventData> SportsmanEvents { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            InitializeTables(builder);
        }
        public static void InitializeTables(ModelBuilder builder)
        {
            if (builder is null) return;
            builder.Entity<EventData>().ToTable(nameof(Events)).HasKey(x => new {x.EventListId, x.OrganizationId, x.TypeId, x.SportCategoryId});
            builder.Entity<EventListData>().ToTable(nameof(EventLists));
            builder.Entity<LocationData>().ToTable(nameof(Locations));
            builder.Entity<OrganizationData>().ToTable(nameof(Organizations));
            builder.Entity<SportCategoryData>().ToTable(nameof(SportCategories));
            builder.Entity<SportCategoryTypeData>().ToTable(nameof(SportCategoryTypes));
            builder.Entity<SportsmanData>().ToTable(nameof(Sportsmen));
            builder.Entity<SportsmanEventData>().ToTable(nameof(SportsmanEvents)).HasKey(x => new { x.SportsmanId, x.EventId });

        }
    }
}
