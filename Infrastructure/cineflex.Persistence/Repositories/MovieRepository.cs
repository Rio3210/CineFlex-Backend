using cineflex.Application.Contracts.Persistence;
using cineflex.Application.Dtos.MovieDto;
using cineflex.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cineflex.Persistence.Repositories
{
    public class MovieRepository : GenericRepository<Movie>, IMoviesRepository
    {
        public MovieRepository(CinemaMovieDbContext dbContext) : base(dbContext)
        {
        }

        public Task<Movie> GetByName(string name)
        {
            var movie = _dbContext.movies.FirstOrDefaultAsync(q => q.Title == name );
            return movie;
        }
    }
}
