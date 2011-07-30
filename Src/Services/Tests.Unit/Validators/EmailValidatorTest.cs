using FluentValidation.Results;
using Kallivayalil.Common;
using Kallivayalil.Common.Extensions;
using Kallivayalil.Domain;
using Kallivayalil.Domain.Validators;
using NUnit.Framework;
using Tests.Common.Mothers;

namespace Tests.Unit.Validators
{
    [TestFixture]
    public class EmailValidatorTest : ValidatorTestBase
    {
        private Email official;
        private EmailValidator validator;

        [SetUp]
        public void SetUp()
        {
            official =
                EmailMother.Official(ConstituentMother.ConstituentWithName(ConstituentNameMother.JamesFranklin()));
            validator = new EmailValidator();
        }

        [Test]
        public void HappyPath()
        {
            ValidationResult result = validator.Validate(official);

            Assert.IsTrue(result.IsValid);
            Assert.That(result.Errors.Count, Is.EqualTo(0));
        }

        [Test]
        public void TypeValidation()
        {
            official.Type = null;
            ValidationResult result = validator.Validate(official);
            AssertInavlidField(result, "Type", MessageConstants.FieldCannotBeNull);
        }

        [Test]
        public void ConstituentValidation()
        {
            official.Constituent = null;
            ValidationResult result = validator.Validate(official);
            AssertInavlidField(result, "Constituent", MessageConstants.FieldCannotBeNull);
        }

        [Test]
        public void AddressValidation()
        {
            official.Address = string.Empty;
            ValidationResult result = validator.Validate(official);
            AssertInavlidField(result, "Address", MessageConstants.FieldCannotBeNullOrEmpty);

            official.Address = "a".Repeat(100);
            result = validator.Validate(official);
            AssertInavlidField(result, "Address", MessageConstants.FieldTooLong);
        }
    }
}