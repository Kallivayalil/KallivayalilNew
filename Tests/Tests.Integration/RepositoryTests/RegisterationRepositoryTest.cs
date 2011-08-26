using System;
using Kallivayalil.DataAccess.Repositories;
using Kallivayalil.Domain;
using NUnit.Framework;
using Tests.Common.Helpers;
using Tests.Common.Mothers;

namespace Tests.Integration.RepositoryTests
{
    [TestFixture]
    public class RegisterationRepositoryTest
    {
        private Constituent constituent;
        private RegisterationRepository registerationRepository;
        private TestDataHelper testDataHelper;


        [SetUp]
        public void SetUp()
        {
            testDataHelper = new TestDataHelper();

            constituent = new Constituent {Gender = "M", BornOn = DateTime.Today, BranchName = 1, MaritialStatus = 1, IsRegistered = false};
            constituent.Name = ConstituentNameMother.JamesFranklin();
            
            registerationRepository = new RegisterationRepository();
        }


        [TearDown]
        public void TearDown()
        {
            testDataHelper.session.Clear();
            testDataHelper.HardDeleteLogins();
            testDataHelper.HardDeleteEmails();
            testDataHelper.HardDeletePhones();
            testDataHelper.HardDeleteAddress();
            testDataHelper.HardDeleteConstituents();
            testDataHelper.HardDeleteConstituentNames();
        }


        [Test]
        public void ShouldSaveARegisteratonConstituent()
        {
            var mobileToSave = PhoneMother.Mobile();
            var addressToSave = AddressMother.London();

            var registerationConstituent = new RegisterationConstituent()
                                               {
                                                   Constituent = constituent,
                                                   Phone = mobileToSave,
                                                   Email = "test1@test.com",
                                                   Password=  "password",
                                                   Address = addressToSave
                                               };

            var savedConst = registerationRepository.Save(registerationConstituent);

            Assert.That(savedConst.Constituent.Id, Is.GreaterThan(0));
            Assert.That(savedConst.Constituent.Name.Id, Is.GreaterThan(0));
            Assert.That(savedConst.Phone.Id, Is.GreaterThan(0));
            Assert.That(savedConst.Address.Id, Is.GreaterThan(0));
            Assert.That(savedConst.Password, Is.EqualTo(registerationConstituent.Password));
            Assert.That(savedConst.Email, Is.EqualTo(registerationConstituent.Email));
            
        } 
        
       

    }
}