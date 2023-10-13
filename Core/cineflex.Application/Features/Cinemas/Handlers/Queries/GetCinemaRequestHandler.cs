using AutoMapper;
using cineflex.Application.Contracts.Persistence;
using cineflex.Application.Dtos.CinemaDto;
using cineflex.Application.Features.Cinemas.Requests.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cineflex.Application.Features.Cinemas.Handlers.Queries
{
    public class GetCinemaRequestHandler : IRequestHandler<GetCinemaRequest, GetCinemaDto>
    {


        private readonly ICinemaRepository _cinemasRepository;
        private readonly IMapper _mapper;

        public GetCinemaRequestHandler(ICinemaRepository cinemasRepository, IMapper mapper)
        {
            _cinemasRepository = cinemasRepository;
            _mapper = mapper;
        }

        public async Task<GetCinemaDto> Handle(GetCinemaRequest request, CancellationToken cancellationToken)
        {

            var cinema = (object)null;
           if (request.Name is null) {
                 cinema = await _cinemasRepository.GetById(request.id);
            }
           else
            {
                 cinema = await _cinemasRepository.GetByName(request.Name);
            }

            return _mapper.Map<GetCinemaDto>(cinema);

          
        }
    }
}
