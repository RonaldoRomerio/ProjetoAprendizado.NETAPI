using curriculumManager.src.domain.models;
using curriculumManager.src.infrastructure.database.seeds;
using Microsoft.EntityFrameworkCore;

namespace curriculumManager.src.infrastructure.database.config
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options){}

        public DbSet<User> User { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Experience> Experience { get; set; }
        public DbSet<Education> Education { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<City> City { get; set; }

        public static AppDbContext create(IConfiguration configuration)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlite(configuration.GetConnectionString("dbConnection"));
            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
