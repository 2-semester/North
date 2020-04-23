using Microsoft.EntityFrameworkCore;
using North.Data.SportsmanEvent;
using North.Domain.SportsmanEvent;

namespace North.Infra.SportsmanEvent
{
    public class SportsmanEventDbContext : DbContext
    {
        public DbSet<SportsmanEventData> SportsmanEvents { get; set; }

        public SportsmanEventDbContext(DbContextOptions<SportsmanEventDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            InitializeTables(builder);
        }
        public static void InitializeTables(ModelBuilder builder)
        {
            if (builder is null) return;
            builder.Entity<SportsmanEventData>().ToTable(nameof(SportsmanEventDomain)).HasKey(x => new { x.SportsmanId, x.EventId});
                
        }
    }
}
