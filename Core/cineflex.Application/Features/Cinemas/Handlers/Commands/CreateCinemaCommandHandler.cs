using AutoMapper;
using cineflex.Application.Contracts.Persistence;
using cineflex.Domain;

using cineflex.Application.Responses;
using MediatR;
using cineflex.Application.Features.Cinemas.Requests.Commands;
using cineflex.Application.Dtos.CinemaDto.Validators;

namespace cineflex.Application.Features.Cinemas.Handlers.Commands

{
    public class CreateCinemaCommandHandler : IRequestHandler<CreateCinemaCommand, BaseCommandResponse>
    {

        private readonly ICinemaRepository _cinemasRepository;
        private readonly IMapper _mapper;

        public CreateCinemaCommandHandler(ICinemaRepository cinemasRepository, IMapper mapper)
        {
            _cinemasRepository = cinemasRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateCinemaCommand request, CancellationToken cancellationToken)
        {

            var response = new BaseCommandResponse();


            var validator = new CreateCinemaDtoValidator();
            var validationResult = await validator.ValidateAsync(request.cinemaDataTobeCreate);

     
           if (!validationResult.IsValid)
            {
                    response.Success = false;
                    response.Message = "Creating cinema Failed on Validation";
                    response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                var cinemarequest = _mapper.Map<Cinema>(request.cinemaDataTobeCreate);

                    cinemarequest = await _cinemasRepository.Add(cinemarequest);

                    response.Success = true;
                    response.Message = "Creating CINEMA Request Success";
                    response.Id = cinemarequest.Id;
            }
                     

            return response;
        }
    }
}