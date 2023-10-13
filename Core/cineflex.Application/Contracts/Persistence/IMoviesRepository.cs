using cineflex.Application.Dtos.MovieDto;
using cineflex.Domain;

namespace cineflex.Application.Contracts.Persistence
{
    public interface IMoviesRepository: IGenericRepository<Movie>
    {
        Task<Movie> GetByName(string name);

    }
}
