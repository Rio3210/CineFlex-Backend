using cineflex.Application.Dtos.MovieDto;
using cineflex.Application.Dtos.MovieDto.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace cineflex.Application.Dtos.CinemaDto.Validators
{
    public class CreateCinemaDtoValidator : AbstractValidator<CreateCinemaDto>
    {

        public CreateCinemaDtoValidator()
        {
         
            Include(new ICinemaDtoValidator());

        }
    }
}
