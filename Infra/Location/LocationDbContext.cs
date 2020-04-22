using Microsoft.EntityFrameworkCore;
using North.Data.Location;

namespace North.Infra.Location
{
    public class LocationDbContext : DbContext
    {
        public DbSet<LocationData> Locations { get; set; }

        public LocationDbContext(DbContextOptions<LocationDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            InitializeTables(builder);
        }
        public static void InitializeTables(ModelBuilder builder)
        {
            if (builder is null) return;
            builder.Entity<LocationData>().ToTable(nameof(Locations));
        }
    }
}
