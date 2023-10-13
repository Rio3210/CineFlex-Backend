using cineflex.Application.Contracts.Persistence;
using cineflex.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cineflex.Persistence.Repositories
{
    public class CinemaRepository : GenericRepository<Cinema>, ICinemaRepository
    {
        public CinemaRepository(CinemaMovieDbContext dbContext) : base(dbContext)
        {
        }
        public Task<Cinema> GetByName(string name)
        {
            var movie = _dbContext.cinemas.FirstOrDefaultAsync(q => q.Name == name);
            return movie;
        }
    }
}
