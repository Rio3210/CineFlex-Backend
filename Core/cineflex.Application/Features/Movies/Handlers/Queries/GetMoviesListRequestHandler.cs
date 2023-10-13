using AutoMapper;
using cineflex.Application.Contracts.Persistence;
using cineflex.Application.Dtos.MovieDto;
using cineflex.Application.Features.Movies.Requests.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cineflex.Application.Features.Movies.Handlers.Queries
{
    public class GetMoviesListRequestHandler : IRequestHandler<GetMoviesListRequest, List<GetMovieDto>>
    {


        private readonly IMoviesRepository _moviesRepository;
        private readonly IMapper _mapper;

        public GetMoviesListRequestHandler(IMoviesRepository moviesRepository, IMapper mapper)
        {
            _moviesRepository = moviesRepository;
            _mapper = mapper;
        }

        public async Task<List<GetMovieDto>> Handle(GetMoviesListRequest request, CancellationToken cancellationToken)
        {

            var allMovies =  await _moviesRepository.GetAll();

            var allReqs = _mapper.Map<List<GetMovieDto>>(allMovies);
            return allReqs;
        }
    }
}
