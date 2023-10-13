using cineflex.Application;
using cineflex.Application.Contracts.Persistence;
using cineflex.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cineflex.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
           services.AddEntityFrameworkNpgsql().AddDbContext<CinemaMovieDbContext>(
    opt => opt.UseNpgsql(configuration.GetConnectionString("DbConnectionString"))
);


            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<IMoviesRepository, MovieRepository>();
            services.AddScoped<ICinemaRepository, CinemaRepository>();

            return services;
        }
    }
}
