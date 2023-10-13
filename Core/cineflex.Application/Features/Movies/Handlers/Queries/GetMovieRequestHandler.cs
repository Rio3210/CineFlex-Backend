using AutoMapper;
using cineflex.Application.Contracts.Persistence;
using cineflex.Application.Dtos.MovieDto;
using cineflex.Application.Features.Movies
    
    .Requests.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cineflex.Application.Features.Movies.Handlers.Queries
{
    public class GetMovieRequestHandler : IRequestHandler<GetMovieRequest, GetMovieDto>
    {


        private readonly IMoviesRepository _moviesRepository;
        private readonly IMapper _mapper;

        public GetMovieRequestHandler(IMoviesRepository moviesRepository, IMapper mapper)
        {
            _moviesRepository = moviesRepository;
            _mapper = mapper;
        }

        public async Task<GetMovieDto> Handle(GetMovieRequest request, CancellationToken cancellationToken)
        {

            var movie = (object)null;
           if (request.Title is null) {
                 movie = await _moviesRepository.GetById(request.id);
            }
           else
            {
                 movie = await _moviesRepository.GetByName(request.Title);
            }

            return _mapper.Map<GetMovieDto>(movie);

          
        }
    }
}
