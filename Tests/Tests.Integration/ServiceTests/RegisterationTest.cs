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
            testDataHelper.CreateConstituent(ConstituentMother.ConstituentWithName(ConstituentNameMother.AgnesAlba()));
            constituentData = new ConstituentData { Gender = "F", BornOn = DateTime.Now, BranchName = new BranchTypeData { Id = 1, Description = "Kallivayalil" }, MaritialStatus = 1 };
            constituentData.Name = new ConstituentNameData {FirstName = "James", LastName = "Franklin", Salutation = new SalutationTypeData {Id = 1, Description = "Mr"}};
        }

        [TearDown]
        public void TearDown()
        {
            testDataHelper.HardDeleteLogins();
            testDataHelper.HardDeleteEmails();
            testDataHelper.HardDeletePhones();
            testDataHelper.HardDeleteAddress();
            testDataHelper.HardDeleteConstituents();
            testDataHelper.HardDeleteConstituentNames();
        }


        [Test]
        public void ShouldFetchConstituentsWhoHaveAppliedForRegistration()
        {
            testDataHelper.CreateConstituent(ConstituentMother.ConstituentWithName(ConstituentNameMother.JamesFranklin(),'A'));
            testDataHelper.CreateConstituent(ConstituentMother.ConstituentWithName(ConstituentNameMother.AgnesAlba(),'A'));

            var constituentsData = HttpHelper.Get<ConstituentsData>(baseUri + "s");

            Assert.That(constituentsData.Count,Is.EqualTo(2));
        }

        [Test]
        public void ShouldRegisterAConstituent()
        {
            var newConstituent = testDataHelper.CreateConstituent(ConstituentMother.ConstituentWithName(ConstituentNameMother.JamesFranklin(), 'A'));
            var official = EmailMother.Official(newConstituent);
            official.IsPrimary = true;
            var emailForNew = testDataHelper.CreateEmail(official);

            var oldConstituent = testDataHelper.CreateConstituent(ConstituentMother.ConstituentWithName(ConstituentNameMother.JamesFranklin(), 'R'));
            var official1 = EmailMother.Official(oldConstituent);
            official1.IsPrimary = true;
            var email = testDataHelper.CreateEmail(official1);
            testDataHelper.CreateLogin(new Login() {Email = email, Password = "Pass", IsAdmin = false});

            var confirmRegisterationData = new ConfirmRegisterationData
                                               {
                                                   Constituent = oldConstituent.Id,
                                                   ConstituentToRegister = newConstituent.Id,
                                                   IsAdmin = false,
                                                   UpdateAndRegister = false
                                               };

            HttpHelper.Post(baseUri + "/RegisterConstituent", confirmRegisterationData);

            testDataHelper.session.Clear();
            Assert.IsNull(testDataHelper.session.Get<Constituent>(newConstituent.Id));

            var registeredConstituent = testDataHelper.session.Load<Constituent>(oldConstituent.Id);
            Assert.IsTrue(registeredConstituent.IsRegistered.ToString().Equals("R"));
            
            var primaryEmail = testDataHelper.LoadPrimaryEmail(oldConstituent.Id);
            var login = testDataHelper.LoadLoginInfo(primaryEmail);
            Assert.IsNotNull(login);

        }

        [Test]
        public void ShouldCreateRegisterationConstituent()
        {
            var registerationData = new RegisterationData()
                                        {
                                            Constituent = constituentData,
                                            Phone = PhoneDataMother.Mobile(),
                                            Email = EmailDataMother.Official().Address,
                                            Password = "Password",
                                            Address = AddressDataMother.London(),
                                        };

            var savedRegisterationConstituent = HttpHelper.Post(baseUri, registerationData);

            Assert.IsNotNull(savedRegisterationConstituent);
            Assert.That(savedRegisterationConstituent.Constituent.Id, Is.GreaterThan(0));
            Assert.That(savedRegisterationConstituent.Constituent.Name.Id, Is.GreaterThan(0));
            Assert.That(savedRegisterationConstituent.Phone.Id, Is.GreaterThan(0));
            Assert.That(savedRegisterationConstituent.Address.Id, Is.GreaterThan(0));
            Assert.That(savedRegisterationConstituent.Email, Is.Not.Null);
            Assert.That(savedRegisterationConstituent.Password, Is.Not.Null);
        }

    }
}