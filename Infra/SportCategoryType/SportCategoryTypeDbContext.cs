using Microsoft.EntityFrameworkCore;
using North.Data.SportCategoryType;

namespace North.Infra.SportCategoryType
{
    public class SportCategoryTypeDbContext : DbContext
    {
        public DbSet<SportCategoryTypeData> SportCategoryTypes { get; set; }

        public SportCategoryTypeDbContext(DbContextOptions<SportCategoryTypeDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            InitializeTables(builder);
        }
        public static void InitializeTables(ModelBuilder builder)
        {
            if (builder is null) return;
            builder.Entity<SportCategoryTypeData>().ToTable(nameof(SportCategoryType));
        }
    }
}
