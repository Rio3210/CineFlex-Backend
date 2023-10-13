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
    public class UpdateMovieCommand : IRequest<BaseCommandResponse>
    {
        public UpdateMovieDto UpdateMovieData { get; set; }

    }
}
