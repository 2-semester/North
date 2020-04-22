using Microsoft.EntityFrameworkCore;
using North.Data.Organization;

namespace North.Infra.Organization
{
    public class OrganizationDbContext : DbContext
    {
        public DbSet<OrganizationData> Organizations { get; set; }

        public OrganizationDbContext(DbContextOptions<OrganizationDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            InitializeTables(builder);
        }
        public static void InitializeTables(ModelBuilder builder)
        {
            if (builder is null) return;
            builder.Entity<OrganizationData>().ToTable(nameof(Organizations));
        }
    }
}
