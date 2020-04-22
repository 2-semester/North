using Microsoft.EntityFrameworkCore;
using North.Data.SportCategory;

namespace North.Infra.SportCategory
{
    public class SportCategoryDbContext : DbContext
    {
        public DbSet<SportCategoryData> SportCategories { get; set; }

        public SportCategoryDbContext(DbContextOptions<SportCategoryDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            InitializeTables(builder);
        }
        public static void InitializeTables(ModelBuilder builder)
        {
            if (builder is null) return;
            builder.Entity<SportCategoryData>().ToTable(nameof(SportCategory));
        }
    }
}
