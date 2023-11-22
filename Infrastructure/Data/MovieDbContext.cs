using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Data
{
    public class MovieDbContext: DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Image> PosterImages { get; set; }
        public IConfiguration Configuration { get; }

        public MovieDbContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = Configuration.GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlite(connectionString, 
                b => b.MigrationsAssembly("AlliedTestApi"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }


    }
}
