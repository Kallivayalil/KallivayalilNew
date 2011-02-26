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
    public class ConstituentNameValidatorTest : ValidatorTestBase
    {
        private ConstituentName jamesFranklin;
        private ConstituentNameValidator validator;

        [SetUp]
        public void SetUp()
        {
            jamesFranklin = ConstituentNameMother.JamesFranklin();
            validator = new ConstituentNameValidator();
        }

        [Test]
        public void HappyPath()
        {
            ValidationResult result = validator.Validate(jamesFranklin);

            Assert.IsTrue(result.IsValid);
            Assert.That(result.Errors.Count,Is.EqualTo(0));
        }

        [Test]
        public void FirstNameValidation()
        {
            jamesFranklin.FirstName = "";
            ValidationResult result = validator.Validate(jamesFranklin);
            AssertInavlidField(result, "FirstName", MessageConstants.FieldCannotBeNullOrEmpty);

            jamesFranklin.FirstName = "a".Repeat(100);
            result = validator.Validate(jamesFranklin);
            AssertInavlidField(result, "FirstName", MessageConstants.FieldTooLong);
        }
       
        [Test]
        public void MiddleNameValidation()
        {
            jamesFranklin.MiddleName = "a".Repeat(100);
            ValidationResult result = validator.Validate(jamesFranklin);
            AssertInavlidField(result, "MiddleName", MessageConstants.FieldTooLong);
        }  
        
        [Test]
        public void PreferredNameValidation()
        {
            jamesFranklin.PreferedName = "a".Repeat(100);
            ValidationResult result = validator.Validate(jamesFranklin);
            AssertInavlidField(result, "PreferedName", MessageConstants.FieldTooLong);
        }

        [Test]
        public void LastNameValidation()
        {
            jamesFranklin.LastName = "";
            ValidationResult result = validator.Validate(jamesFranklin);
            AssertInavlidField(result, "LastName", MessageConstants.FieldCannotBeNullOrEmpty);

            jamesFranklin.LastName = "a".Repeat(100);
            result = validator.Validate(jamesFranklin);
            AssertInavlidField(result, "LastName", MessageConstants.FieldTooLong);
        }
    }
}