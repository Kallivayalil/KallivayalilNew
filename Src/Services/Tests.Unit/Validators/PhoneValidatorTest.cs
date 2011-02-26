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
    public class PhoneValidatorTest : ValidatorTestBase
    {
        private Phone mobile;
        private PhoneValidator validator;

        [SetUp]
        public void SetUp()
        {
            mobile = PhoneMother.Mobile(ConstituentMother.ConstituentWithName(ConstituentNameMother.JamesFranklin()));
            validator = new PhoneValidator();
        }

        [Test]
        public void HappyPath()
        {
            ValidationResult result = validator.Validate(mobile);

            Assert.IsTrue(result.IsValid);
            Assert.That(result.Errors.Count,Is.EqualTo(0));
        }

        [Test]
        public void TypeValidation()
        {
            mobile.Type = null;
            ValidationResult result = validator.Validate(mobile);
            AssertInavlidField(result, "Type", MessageConstants.FieldCannotBeNull);
        }

        [Test]
        public void ConstituentValidation()
        {
            mobile.Constituent = null;
            ValidationResult result = validator.Validate(mobile);
            AssertInavlidField(result, "Constituent", MessageConstants.FieldCannotBeNull);
        }

     

        [Test]
        public void NumberValidation()
        {
            mobile.Number = string.Empty;
            ValidationResult result = validator.Validate(mobile);
            AssertInavlidField(result, "Number", MessageConstants.FieldCannotBeNullOrEmpty);

            mobile.Number = "a".Repeat(100);
            result = validator.Validate(mobile);
            AssertInavlidField(result, "Number", MessageConstants.FieldTooLong);
        }


    }
}