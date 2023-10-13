
using cineflex.Application.Dtos.MovieDto;
using MediatR;

namespace cineflex.Application.Features.Movies.Requests.Queries
{
    public class GetMovieRequest : IRequest<GetMovieDto>
    {
        public string Title { get; set; }
        public int id { get; set; }

    }
}
