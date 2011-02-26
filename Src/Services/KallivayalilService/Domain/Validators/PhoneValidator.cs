using FluentValidation;
using Kallivayalil.Common;

namespace Kallivayalil.Domain.Validators
{
    public class PhoneValidator : AbstractValidator<Phone>
    {
        public PhoneValidator()
        {

            RuleFor(email => email.Type).NotNull().WithMessage(MessageConstants.FieldCannotBeNull);

            RuleFor(email => email.Number).Must(s => !string.IsNullOrEmpty(s)).WithMessage(MessageConstants.FieldCannotBeNullOrEmpty);
            RuleFor(email => email.Number).Length(0, 20).WithMessage(MessageConstants.FieldTooLong);

            RuleFor(email => email.Constituent).NotNull().WithMessage(MessageConstants.FieldCannotBeNull);
        }
    }
}