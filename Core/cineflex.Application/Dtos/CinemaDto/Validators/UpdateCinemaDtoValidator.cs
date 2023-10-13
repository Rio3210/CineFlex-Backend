using cineflex.Application.Dtos.CinemaDto.Validators;
using cineflex.Application.Dtos.MovieDto;
using cineflex.Application.Dtos.MovieDto.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace cineflex.Application.Dtos.CinemaDto
{
    public class UpdateCinemaDtoValidator: AbstractValidator<UpdateCinemaDto>
    {

        public UpdateCinemaDtoValidator()
        {
            Include(new ICinemaDtoValidator());

            RuleFor(x => x.Id)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} is required");
             
        }

    }
}
