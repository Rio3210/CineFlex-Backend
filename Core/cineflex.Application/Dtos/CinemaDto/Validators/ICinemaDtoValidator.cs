using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace cineflex.Application.Dtos.CinemaDto.Validators
{
    public class ICinemaDtoValidator : AbstractValidator<ICinemaDto>
    {

        public ICinemaDtoValidator()
        {
            RuleFor(x => x.Name)
             .NotEmpty().WithMessage("{PropertyName} is required")
             .NotNull()
             .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters")
             .MinimumLength(2).WithMessage("{PropertyName} must be at least 2 characters");

            RuleFor(x => x.Location)
           .NotEmpty().WithMessage("{PropertyName} is required")
           .NotNull()
           .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters")
           .MinimumLength(2).WithMessage("{PropertyName} must be at least 2 characters");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("{PropertyName} is required");
                

        }
    }
}
