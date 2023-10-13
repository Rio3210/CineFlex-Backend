using AutoMapper;
using cineflex.Application.Contracts.Persistence;
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
    public class DeleteMovieCommandHandler : IRequestHandler<DeleteMovieCommand, BaseCommandResponse>
    {

        private readonly IMoviesRepository _moviesRepository;
        private readonly IMapper _mapper;

        public DeleteMovieCommandHandler(IMoviesRepository moviesRepository, IMapper mapper)
        {
            _moviesRepository = moviesRepository;
            _mapper = mapper;
        }

        public async  Task<BaseCommandResponse> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
        {
            var movieTobeDeleted = await _moviesRepository.GetById(request.Id);


            var response = new BaseCommandResponse();

            
            if ( movieTobeDeleted == null)
             {
                response.Success = false;
                response.Message = "Deleting movie Failed on Validation or Exception";
             }
             else
             {
              await _moviesRepository.Delete(movieTobeDeleted);

                response.Success = true;
                response.Message = "Deleting movie Request Success";
                response.Id = movieTobeDeleted.Id;
             }
             


            return response;
        }
    }
}
