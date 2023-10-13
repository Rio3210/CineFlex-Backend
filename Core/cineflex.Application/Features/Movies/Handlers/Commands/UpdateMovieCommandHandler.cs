using AutoMapper;
using cineflex.Application.Contracts.Persistence;
using cineflex.Application.Dtos.MovieDto;
using cineflex.Application.Features.Movies.Requests.Commands;
using cineflex.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cineflex.Application.Features.Movies.Handlers.Commands
{
    public class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommand, BaseCommandResponse>
    {

        private readonly IMoviesRepository _moviesRepository;
        private readonly IMapper _mapper;

        public UpdateMovieCommandHandler(IMoviesRepository moviesRepository, IMapper mapper)
        {
            _moviesRepository = moviesRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
        {

            var response = new BaseCommandResponse();


       
            var validator = new UpdateMovieDtoValidator();
            var validationResult = await validator.ValidateAsync(request.UpdateMovieData);
            


           if (!validationResult.IsValid)
               {
                    response.Success = false;
                    response.Message = "updating Movie Request Failed on Validation";
                    response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
               }
            else
                {

                    var movietobeUpdated = await _moviesRepository.GetById(request.UpdateMovieData.Id);

                    _mapper.Map(request.UpdateMovieData, movietobeUpdated);

                    await _moviesRepository.Update(movietobeUpdated);

                    response.Success = true;
                    response.Message = "updating Movie Request Success";
                    response.Id = movietobeUpdated.Id;
                }
 
           

            return response;
        }
    }
}
