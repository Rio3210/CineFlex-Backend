using cineflex.Application.Dtos.MovieDto;
using cineflex.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cineflex.Application.Features.Movies.Requests.Commands
{
    public class CreateMovieCommand : IRequest<BaseCommandResponse>
    {
        public CreateMovieDto movieDataTobeCreate { get; set; }
    }
}
