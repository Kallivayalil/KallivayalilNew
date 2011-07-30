using FluentValidation.Results;
using NUnit.Framework;

namespace Tests.Unit.Validators
{
    public class ValidatorTestBase
    {
        public void AssertInavlidField(ValidationResult result, string fieldName, string message)
        {
            Assert.IsFalse(result.IsValid);
            Assert.That(result.Errors.Count, Is.EqualTo(1));
            Assert.That(result.Errors[0].PropertyName, Is.EqualTo(fieldName));
            Assert.That(result.Errors[0].ErrorMessage, Is.EqualTo(message));
        }
    }
}