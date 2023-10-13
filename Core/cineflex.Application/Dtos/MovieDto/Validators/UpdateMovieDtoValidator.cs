﻿using cineflex.Application.Dtos.MovieDto;
using cineflex.Application.Dtos.MovieDto.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace cineflex.Application.Dtos.MovieDto
{
    public class UpdateMovieDtoValidator: AbstractValidator<UpdateMovieDto>
    {

        public UpdateMovieDtoValidator()
        {
            Include(new IMovieDtoValidator());

            RuleFor(x => x.Id)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} is required");
             
        }

    }
}
