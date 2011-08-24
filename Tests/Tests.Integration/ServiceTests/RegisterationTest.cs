using System;
using System.Net;
using Kallivayalil.Client;
using Kallivayalil.Domain;
using NUnit.Framework;
using Tests.Common.Helpers;
using Tests.Common.Mothers;
using Tests.Integration.Mothers;

namespace Tests.Integration.ServiceTests
{
    [TestFixture]
    public class RegisterationTest
    {
        private string baseUri = "http://localhost/kallivayalilService/KallivayalilService.svc/Registration";
        private TestDataHelper testDataHelper;
        private Constituent constituent;
        private ConstituentData constituentData;

        [SetUp]
        public void SetUp()
        {
            testDataHelper = new TestDataHelper();
            constituent = testDataHelper.CreateConstituent(ConstituentMother.ConstituentWithName(ConstituentNameMother.JamesFranklin()));
            testDataHelper.CreateConstituent(ConstituentMother.ConstituentWithName(ConstituentNameMother.JessicaAlba()));
            constituentData = new ConstituentData {Gender = "F", BornOn = DateTime.Now, BranchName = 1, MaritialStatus = 1, IsRegistered = false};
            constituentData.Name = new ConstituentNameData {FirstName = "James", LastName = "Franklin", Salutation = new SalutationTypeData {Id = 1, Description = "Mr"}};
        }

        [TearDown]
        public void TearDown()
        {
            testDataHelper.HardDeleteEmails();
            testDataHelper.HardDeletePhones();
            testDataHelper.HardDeleteAddress();
            testDataHelper.HardDeleteConstituents();
            testDataHelper.HardDeleteConstituentNames();
        }


        [Test]
        public void ShouldLoadConstituent()
        {
            var result = HttpHelper.Get<ConstituentData>(string.Format("{0}/{1}", baseUri, constituent.Id));
            Assert.IsNotNull(result);
        }

        [Test]
        public void ShouldCreateRegisterationConstituent()
        {
            var registerationData = new RegisterationData()
                                        {
                                            Constituent = constituentData,
                                            Phone = PhoneDataMother.Mobile(),
                                            Email = EmailDataMother.Official(),
                                            Address = AddressDataMother.London()
                                        };

            var savedRegisterationConstituent = HttpHelper.Post(baseUri, registerationData);

            Assert.IsNotNull(savedRegisterationConstituent);
            Assert.That(savedRegisterationConstituent.Constituent.Id, Is.GreaterThan(0));
            Assert.That(savedRegisterationConstituent.Constituent.Name.Id, Is.GreaterThan(0));
            Assert.That(savedRegisterationConstituent.Phone.Id, Is.GreaterThan(0));
            Assert.That(savedRegisterationConstituent.Address.Id, Is.GreaterThan(0));
            Assert.That(savedRegisterationConstituent.Email.Id, Is.GreaterThan(0));
        }

    }
}