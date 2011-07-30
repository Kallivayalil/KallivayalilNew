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
    public class AddressValidatorTest : ValidatorTestBase
    {
        private Address sanFrancisco;
        private AddressValidator validator;

        [SetUp]
        public void SetUp()
        {
            sanFrancisco = AddressMother.SanFrancisco(ConstituentMother.ConstituentWithName(ConstituentNameMother.JamesFranklin()));
            validator = new AddressValidator();
        }

        [Test]
        public void HappyPath()
        {
            ValidationResult result = validator.Validate(sanFrancisco);

            Assert.IsTrue(result.IsValid);
            Assert.That(result.Errors.Count, Is.EqualTo(0));
        }

        [Test]
        public void AddressLineValidation()
        {
            sanFrancisco.Line1 = "";
            ValidationResult result = validator.Validate(sanFrancisco);
            AssertInavlidField(result, "Line1", MessageConstants.FieldCannotBeNullOrEmpty);

            sanFrancisco.Line1 = null;
            result = validator.Validate(sanFrancisco);
            AssertInavlidField(result, "Line1", MessageConstants.FieldCannotBeNullOrEmpty);

            sanFrancisco.Line1 = "a".Repeat(150);
            result = validator.Validate(sanFrancisco);
            AssertInavlidField(result, "Line1", MessageConstants.FieldTooLong);

            sanFrancisco.Line1 = "123 street";
            sanFrancisco.Line2 = "";
            result = validator.Validate(sanFrancisco);
            Assert.IsTrue(result.IsValid);

            sanFrancisco.Line2 = "a".Repeat(150);
            result = validator.Validate(sanFrancisco);
            AssertInavlidField(result, "Line2", MessageConstants.FieldTooLong);
        }

        [Test]
        public void CountryValidation()
        {
            sanFrancisco.Country = "";
            ValidationResult result = validator.Validate(sanFrancisco);
            AssertInavlidField(result, "Country", MessageConstants.FieldCannotBeNullOrEmpty);

            sanFrancisco.Country = null;
            result = validator.Validate(sanFrancisco);
            AssertInavlidField(result, "Country", MessageConstants.FieldCannotBeNullOrEmpty);

            sanFrancisco.Country = "a".Repeat(60);
            result = validator.Validate(sanFrancisco);
            AssertInavlidField(result, "Country", MessageConstants.FieldTooLong);
        }

        [Test]
        public void StateValidation()
        {
            sanFrancisco.State = "";
            ValidationResult result = validator.Validate(sanFrancisco);
            AssertInavlidField(result, "State", MessageConstants.FieldCannotBeNullOrEmpty);

            sanFrancisco.State = null;
            result = validator.Validate(sanFrancisco);
            AssertInavlidField(result, "State", MessageConstants.FieldCannotBeNullOrEmpty);

            sanFrancisco.State = "a".Repeat(60);
            result = validator.Validate(sanFrancisco);
            AssertInavlidField(result, "State", MessageConstants.FieldTooLong);
        }

        [Test]
        public void PostCodeValidation()
        {
            sanFrancisco.PostCode = "";
            ValidationResult result = validator.Validate(sanFrancisco);
            AssertInavlidField(result, "PostCode", MessageConstants.FieldCannotBeNullOrEmpty);

            sanFrancisco.PostCode = null;
            result = validator.Validate(sanFrancisco);
            AssertInavlidField(result, "PostCode", MessageConstants.FieldCannotBeNullOrEmpty);

            sanFrancisco.PostCode = "a".Repeat(60);
            result = validator.Validate(sanFrancisco);
            AssertInavlidField(result, "PostCode", MessageConstants.FieldTooLong);
        }

        [Test]
        public void CityValidation()
        {
            sanFrancisco.City = "";
            ValidationResult result = validator.Validate(sanFrancisco);
            AssertInavlidField(result, "City", MessageConstants.FieldCannotBeNullOrEmpty);

            sanFrancisco.City = null;
            result = validator.Validate(sanFrancisco);
            AssertInavlidField(result, "City", MessageConstants.FieldCannotBeNullOrEmpty);

            sanFrancisco.City = "a".Repeat(60);
            result = validator.Validate(sanFrancisco);
            AssertInavlidField(result, "City", MessageConstants.FieldTooLong);
        }

        [Test]
        public void ConstituentAndTypeForAddressValidation()
        {
            var constituent = sanFrancisco.Constituent;
            sanFrancisco.Constituent = null;
            ValidationResult result = validator.Validate(sanFrancisco);
            AssertInavlidField(result, "Constituent", MessageConstants.FieldCannotBeNull);

            sanFrancisco.Type = null;
            sanFrancisco.Constituent = constituent;
            result = validator.Validate(sanFrancisco);
            AssertInavlidField(result, "Type", MessageConstants.FieldCannotBeNull);
        }
    }
}