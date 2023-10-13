using AutoMapper;
using cineflex.Application.Contracts.Persistence;
using cineflex.Application.Dtos.CinemaDto;
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
    public class UpdateCinemaCommandHandler : IRequestHandler<UpdateCinemaCommand, BaseCommandResponse>
    {

        private readonly ICinemaRepository _cinemasRepository;
        private readonly IMapper _mapper;

        public UpdateCinemaCommandHandler(ICinemaRepository cinemasRepository, IMapper mapper)
        {
            _cinemasRepository = cinemasRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(UpdateCinemaCommand request, CancellationToken cancellationToken)
        {

            var response = new BaseCommandResponse();


            var validator = new UpdateCinemaDtoValidator();
            var validationResult = await validator.ValidateAsync(request.UpdateCinemaData);
            

                    if (!validationResult.IsValid)
                {
                    response.Success = false;
                    response.Message = "updating Cinema Request Failed on Validation";
                    response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                }
                 else
                {

                var cinematobeUpdated = await _cinemasRepository.GetById(request.UpdateCinemaData.Id);

                _mapper.Map(request.UpdateCinemaData, cinematobeUpdated);

                await _cinemasRepository.Update(cinematobeUpdated);

                response.Success = true;
                response.Message = "updating Cinema Request Success";
                response.Id = cinematobeUpdated.Id;
                }
 

            return response;
        }
    }
}
