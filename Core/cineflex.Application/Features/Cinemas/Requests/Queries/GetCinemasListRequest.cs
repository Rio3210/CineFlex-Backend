using cineflex.Application.Dtos.CinemaDto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cineflex.Application.Features.Cinemas.Requests.Queries
{
    public class GetCinemasListRequest : IRequest<List<GetCinemaDto>>
    {

    }
}