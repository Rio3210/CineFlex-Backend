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
    public class GetCinemasListRequestHandler : IRequestHandler<GetCinemasListRequest, List<GetCinemaDto>>
    {


        private readonly ICinemaRepository _cinemasRepository;
        private readonly IMapper _mapper;

        public GetCinemasListRequestHandler(ICinemaRepository cinemasRepository, IMapper mapper)
        {
            _cinemasRepository = cinemasRepository;
            _mapper = mapper;
        }

        public async Task<List<GetCinemaDto>> Handle(GetCinemasListRequest request, CancellationToken cancellationToken)
        {

            var allCinemas =  await _cinemasRepository.GetAll();

            var allReqs = _mapper.Map<List<GetCinemaDto>>(allCinemas);
            return allReqs;
        }
    }
}
