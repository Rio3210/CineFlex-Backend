using cineflex.Domain;
using cineflex.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace cineflex.Persistence
{
    public class CinemaMovieDbContext : DbContext
    {

        public CinemaMovieDbContext(DbContextOptions<CinemaMovieDbContext> options): base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CinemaMovieDbContext).Assembly);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }


        public DbSet<Movie> movies { get; set; }
        public DbSet<Cinema> cinemas { get; set; }
    }
}
