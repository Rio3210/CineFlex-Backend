using cineflex.Application.Dtos.CinemaDto;
using cineflex.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cineflex.Application.Features.Cinemas.Requests.Commands
{
    public class CreateCinemaCommand : IRequest<BaseCommandResponse>
    {
        public CreateCinemaDto cinemaDataTobeCreate { get; set; }
    }
}