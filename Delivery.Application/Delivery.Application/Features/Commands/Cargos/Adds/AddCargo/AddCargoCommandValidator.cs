using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Application.Features.Commands.Cargos.Adds.AddCargo
{
    public class AddCompanyCommandValidator : AbstractValidator<AddCargoCommand>
    {
        public AddCompanyCommandValidator()
        {
            RuleFor(p => p.Name)
               .NotEmpty().WithMessage("{Name} is required.");

            RuleFor(p => p.CargoEnumId)
                .NotEmpty().WithMessage("{CargoEnumId} is required.");
        }
    }
}
