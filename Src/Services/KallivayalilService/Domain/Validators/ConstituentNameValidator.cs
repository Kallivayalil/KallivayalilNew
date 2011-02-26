using FluentValidation;
using Kallivayalil.Common;

namespace Kallivayalil.Domain.Validators
{
    public class ConstituentNameValidator : AbstractValidator<ConstituentName>
    {
        public ConstituentNameValidator()
        {

            RuleFor(constituentName => constituentName.FirstName).Must(s => !string.IsNullOrEmpty(s)).WithMessage(MessageConstants.FieldCannotBeNullOrEmpty);
            RuleFor(constituentName => constituentName.FirstName).Length(0, 50).WithMessage(MessageConstants.FieldTooLong);

            RuleFor(constituentName => constituentName.MiddleName).Length(0, 50).WithMessage(MessageConstants.FieldTooLong);

            RuleFor(constituentName => constituentName.LastName).Must(s => !string.IsNullOrEmpty(s)).WithMessage(MessageConstants.FieldCannotBeNullOrEmpty);
            RuleFor(constituentName => constituentName.LastName).Length(0, 50).WithMessage(MessageConstants.FieldTooLong);

            RuleFor(constituentName => constituentName.PreferedName).Length(0, 50).WithMessage(MessageConstants.FieldTooLong);

            RuleFor(constituentName => constituentName.Salutation).NotNull().WithMessage(MessageConstants.FieldCannotBeNull);
        }
    }
}