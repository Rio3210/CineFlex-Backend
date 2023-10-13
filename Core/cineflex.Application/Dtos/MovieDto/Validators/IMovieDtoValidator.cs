using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace cineflex.Application.Dtos.MovieDto.Validators
{
    public class IMovieDtoValidator : AbstractValidator<IMovieDto>
    {

        public IMovieDtoValidator()
        {
            RuleFor(x => x.Title)
             .NotEmpty().WithMessage("{PropertyName} is required")
             .NotNull()
             .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters")
             .MinimumLength(2).WithMessage("{PropertyName} must be at least 2 characters");

            RuleFor(x => x.Genre)
           .NotEmpty().WithMessage("{PropertyName} is required")
           .NotNull()
           .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters")
           .MinimumLength(2).WithMessage("{PropertyName} must be at least 2 characters");

            RuleFor(x => x.ReleaseYear)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .GreaterThan(1950).WithMessage("{PropertyName} must be AFTER 1950")
                .LessThan(10000).WithMessage("{PropertyName} must be before 10000");

        }
    }
}
