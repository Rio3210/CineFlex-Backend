using cineflex.Domain;

namespace cineflex.Application.Contracts.Persistence
{
    public interface ICinemaRepository : IGenericRepository<Cinema>
    {

        Task<Cinema> GetByName(string name);

    }
}
