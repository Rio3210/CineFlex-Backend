using cineflex.Application.Dtos.CinemaDto;
using MediatR;

namespace cineflex.Application.Features.Cinemas.Requests.Queries
{
    public class GetCinemaRequest : IRequest<GetCinemaDto>
    {
        public string Name { get; set; }
        public int id { get; set; }

    } 
}