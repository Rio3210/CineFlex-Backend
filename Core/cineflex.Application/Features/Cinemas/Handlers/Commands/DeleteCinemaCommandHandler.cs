using AutoMapper;
using cineflex.Application.Contracts.Persistence;
using cineflex.Application.Features.Cinemas.Requests.Commands;
using cineflex.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cineflex.Application.Features.Cinemas.Handlers.Commands
{
    public class DeleteCinemaCommandHandler : IRequestHandler<DeleteCinemaCommand, BaseCommandResponse>
    {

        private readonly ICinemaRepository _cinemasRepository;
        private readonly IMapper _mapper;

        public DeleteCinemaCommandHandler(ICinemaRepository cinemasRepository, IMapper mapper)
        {
            _cinemasRepository = cinemasRepository;
            _mapper = mapper;
        }

        public async  Task<BaseCommandResponse> Handle(DeleteCinemaCommand request, CancellationToken cancellationToken)
        {
            var cinemaTobeDeleted = await _cinemasRepository.GetById(request.Id);


            var response = new BaseCommandResponse();



            if (cinemaTobeDeleted == null)
            {
                response.Success = false;
                response.Message = "Deleting cinema Failed on Validation or Exception";
            }
            else
            {
                await _cinemasRepository.Delete(cinemaTobeDeleted);

                response.Success = true;
                response.Message = "Deleting cinema Request Success";
                response.Id = cinemaTobeDeleted.Id;
            }



            return response;
        }
    }
}
