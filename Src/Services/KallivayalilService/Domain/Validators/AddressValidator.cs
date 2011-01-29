using FluentValidation;

namespace Kallivayalil.Domain.Validators
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(address => address.Line1).Length(0, 100).WithMessage("Field too long.");
            RuleFor(address => address.Line1).NotNull().WithMessage("Mandatory Field.");

            RuleFor(address => address.Line2).Length(0, 100).WithMessage("Field too long.");

            RuleFor(address => address.Country).NotNull().WithMessage("Mandatory Field");
            RuleFor(address => address.Country).Length(0, 50).WithMessage("Field too long");

            RuleFor(address => address.City).NotNull().WithMessage("Mandatory Field");
            RuleFor(address => address.City).Length(0, 50).WithMessage("Field too long");

            RuleFor(address => address.State).NotNull().WithMessage("Mandatory Field");
            RuleFor(address => address.State).Length(0, 50).WithMessage("Field too long");

            RuleFor(address => address.PostCode).NotNull().WithMessage("Mandatory Field");
            RuleFor(address => address.PostCode).Length(0, 10).WithMessage("Field too long");

            RuleFor(address => address.Type).NotNull().WithMessage("Mandatory Field");

            RuleFor(address => address.Constituent).NotNull().WithMessage("Mandatory Field");

            
        }
    }
}
