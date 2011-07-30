using FluentValidation;
using Kallivayalil.Common;

namespace Kallivayalil.Domain.Validators
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(address => address.Line1).Must(s => !string.IsNullOrEmpty(s)).WithMessage(MessageConstants.FieldCannotBeNullOrEmpty);
            RuleFor(address => address.Line1).Length(0, 100).WithMessage(MessageConstants.FieldTooLong);

            RuleFor(address => address.Line2).Length(0, 100).WithMessage(MessageConstants.FieldTooLong);

            RuleFor(address => address.Country).Must(s => !string.IsNullOrEmpty(s)).WithMessage(MessageConstants.FieldCannotBeNullOrEmpty);
            RuleFor(address => address.Country).Length(0, 50).WithMessage(MessageConstants.FieldTooLong);

            RuleFor(address => address.City).Must(s => !string.IsNullOrEmpty(s)).WithMessage(MessageConstants.FieldCannotBeNullOrEmpty);
            RuleFor(address => address.City).Length(0, 50).WithMessage(MessageConstants.FieldTooLong);

            RuleFor(address => address.State).Must(s => !string.IsNullOrEmpty(s)).WithMessage(MessageConstants.FieldCannotBeNullOrEmpty);
            RuleFor(address => address.State).Length(0, 50).WithMessage(MessageConstants.FieldTooLong);

            RuleFor(address => address.PostCode).Must(s => !string.IsNullOrEmpty(s)).WithMessage(MessageConstants.FieldCannotBeNullOrEmpty);
            RuleFor(address => address.PostCode).Length(0, 10).WithMessage(MessageConstants.FieldTooLong);

            RuleFor(address => address.Type).NotNull().WithMessage(MessageConstants.FieldCannotBeNull);

            RuleFor(address => address.Constituent).NotNull().WithMessage(MessageConstants.FieldCannotBeNull);
        }
    }
}