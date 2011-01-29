using FluentValidation.Results;
using Kallivayalil.Domain;
using Kallivayalil.Domain.Exception;

namespace Kallivayalil
{
    public static class ValidationResultExtension
    {
        public static void ProcessValidationResults(this ValidationResult validationResult)
        {
            if (validationResult.IsValid)
            {
                return;
            }

            var errorMessages = new ErrorMessagesEntity();
            foreach (var validationFailure in validationResult.Errors)
            {
                errorMessages.Add(new ErrorMessageEntity{Code = string.Empty,Description = validationFailure.ErrorMessage,ErrorPath = validationFailure.PropertyName});
            }
            throw new ValidationException { ErrorMessages = errorMessages };
        }
    }
}
