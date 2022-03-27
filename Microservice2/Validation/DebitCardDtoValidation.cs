using FluentValidation;
using Microservice2.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice2.Validation
{
    public class DebitCardDtoValidation : AbstractValidator<DebitCardDto>
    {
        public DebitCardDtoValidation()
        {
            RuleFor(x => x.name)
               .NotEmpty()
               .WithMessage(ValidationMessages.DebitCardError);
            RuleFor(x => x.surname)
             .NotEmpty()
               .WithMessage(ValidationMessages.DebitCardError);
            RuleFor(x => x.money)
              .NotEmpty()
               .WithMessage(ValidationMessages.DebitCardError);

        }
    }
}
