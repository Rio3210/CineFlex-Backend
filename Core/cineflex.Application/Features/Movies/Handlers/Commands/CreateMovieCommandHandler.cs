using AutoMapper;
using cineflex.Application.Contracts.Persistence;
using cineflex.Domain;

using cineflex.Application.Responses;
using MediatR;
using cineflex.Application.Features.Movies.Requests.Commands;
using cineflex.Application.Dtos.MovieDto.Validators;

namespace cineflex.Application.Features.Movies.Handlers.Commands
{
    public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, BaseCommandResponse>
    {

        private readonly IMoviesRepository _moviesRepository;
        private readonly IMapper _mapper;

        public CreateMovieCommandHandler(IMoviesRepository moviesRepository, IMapper mapper)
        {
            _moviesRepository = moviesRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
        {

            var response = new BaseCommandResponse();


            var validator = new CreateMovieDtoValidator();
            var validationResult = await validator.ValidateAsync(request.movieDataTobeCreate);

                    
            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Creating movie Failed on Validation";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                var movierequest = _mapper.Map<Movie>(request.movieDataTobeCreate);

            movierequest = await _moviesRepository.Add(movierequest);

            response.Success = true;
            response.Message = "Creating movie Request Success";
            response.Id = movierequest.Id;
             }


            return response;
        }
    }
}