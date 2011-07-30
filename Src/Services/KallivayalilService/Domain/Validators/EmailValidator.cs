using FluentValidation;
using Kallivayalil.Common;

namespace Kallivayalil.Domain.Validators
{
    public class EmailValidator : AbstractValidator<Email>
    {
        public EmailValidator()
        {
            RuleFor(email => email.Type).NotNull().WithMessage(MessageConstants.FieldCannotBeNull);

            RuleFor(email => email.Address).Must(s => !string.IsNullOrEmpty(s)).WithMessage(MessageConstants.FieldCannotBeNullOrEmpty);
            RuleFor(email => email.Address).Length(0, 50).WithMessage(MessageConstants.FieldTooLong);

            RuleFor(email => email.Constituent).NotNull().WithMessage(MessageConstants.FieldCannotBeNull);
        }
    }
}