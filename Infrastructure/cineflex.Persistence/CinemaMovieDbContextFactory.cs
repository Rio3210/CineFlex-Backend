using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace cineflex.Persistence;



    public class CinemaMovieDbContextFactory : IDesignTimeDbContextFactory<CinemaMovieDbContext>
    {
        public CinemaMovieDbContext CreateDbContext(string[] args)
        {

            string basePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, "cineflex.Api");
            Console.WriteLine("***********************************************");

            Console.WriteLine($"{basePath}");
            Console.WriteLine("***********************************************");




        IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .Build();


            var builder = new DbContextOptionsBuilder<CinemaMovieDbContext>();
            var connectionString = configuration.GetConnectionString("DbConnectionString");

            builder.UseNpgsql(connectionString);

            return new CinemaMovieDbContext(builder.Options);

        }
    }