using cineflex.Application.Dtos.MovieDto;
using cineflex.Application.Dtos.MovieDto.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace cineflex.Application.Dtos.MovieDto.Validators
{
    public class CreateMovieDtoValidator : AbstractValidator<CreateMovieDto>
    {

        public CreateMovieDtoValidator()
        {
         
            Include(new IMovieDtoValidator());

        }
    }
}
