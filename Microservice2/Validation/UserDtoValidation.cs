using FluentValidation;
using Microservice2.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice2.Validation
{
    public class UserDtoValidation : AbstractValidator<UserDto>
    {
        public UserDtoValidation()
        {
            RuleFor(x => x.Username)
               .NotEmpty()
               .WithMessage(ValidationMessages.UserError);
            RuleFor(x => x.Password)
              .NotEmpty()
                .WithMessage(ValidationMessages.UserError);
            RuleFor(x => x.Role)
             .NotEmpty()
               .WithMessage(ValidationMessages.UserError);

        }
    }
}
