using curriculumManager.src.domain.models;
using Microsoft.EntityFrameworkCore;

namespace curriculumManager.src.infrastructure.database.config
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            base.OnConfiguring(optionsBuilder);

        public static AppDbContext create(IConfiguration configuration)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlite(configuration.GetConnectionString("dbConnection"));
            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
