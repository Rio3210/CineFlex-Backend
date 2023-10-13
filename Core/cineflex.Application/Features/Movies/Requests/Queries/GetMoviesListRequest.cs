using cineflex.Application.Dtos.MovieDto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cineflex.Application.Features.Movies.Requests.Queries
{
    public class GetMoviesListRequest : IRequest<List<GetMovieDto>>
    {

    }
}
