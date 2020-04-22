using Microsoft.EntityFrameworkCore;
using North.Data.Sportsman;

namespace North.Infra.Sportsman
{
    public class SportsmanDbContext : DbContext
    {
        public DbSet<SportsmanData> Sportsmen { get; set; }

        public SportsmanDbContext(DbContextOptions<SportsmanDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            InitializeTables(builder);
        }
        public static void InitializeTables(ModelBuilder builder)
        {
            if (builder is null) return;
            builder.Entity<SportsmanData>().ToTable(nameof(Sportsman));
        }
    }
}
