using Kallivayalil.DataAccess.Repositories;
using Kallivayalil.Domain;
using NUnit.Framework;
using Tests.Common.Helpers;
using Tests.Common.Mothers;

namespace Tests.Integration.RepositoryTests
{
    [TestFixture]
    public class PhoneRepositoryTest
    {
        private TestDataHelper testDataHelper;
        private Constituent savedConstituent;
        private Address savedAddress;
        private PhoneRepository phoneRepository;
        private Phone savedPhone;

        [SetUp]
        public void SetUp()
        {
            testDataHelper = new TestDataHelper();
            var constituent = ConstituentMother.ConstituentWithName(ConstituentNameMother.JamesFranklin());
            savedConstituent = testDataHelper.CreateConstituent(constituent);
            savedAddress = testDataHelper.CreateAddress(AddressMother.SanFrancisco(savedConstituent));
            phoneRepository = new PhoneRepository(testDataHelper.session);
            savedPhone = testDataHelper.CreatePhone(PhoneMother.Mobile(savedConstituent, savedAddress));

        }

        [TearDown]
        public void TearDown()
        {
            testDataHelper.HardDeletePhones();
            testDataHelper.HardDeleteAddress();
            testDataHelper.HardDeleteConstituents();
            testDataHelper.HardDeleteConstituentNames();
        }

        [Test]
        public void ShouldSavePhone()
        {
            var phone = phoneRepository.Save(PhoneMother.Mobile(savedConstituent));
            Assert.That(phone.Id,Is.GreaterThan(0));
            Assert.IsNull(phone.Address);
        }

        [Test]
        public void ShouldSavePhoneWithAddress()
        {
            var phone = phoneRepository.Save(PhoneMother.Mobile(savedConstituent, savedAddress));
            Assert.That(phone.Id, Is.GreaterThan(0));
            Assert.That(phone.Address.Id,Is.EqualTo(savedAddress.Id));

        }

        [Test]
        public void ShouldUpdateExistingPhone()
        {
            const string newNumber = "123-123";

            savedPhone.Number = newNumber;
            savedPhone.Address = null;

            var updatedPhone = phoneRepository.Update(savedPhone);
            Assert.That(updatedPhone.Number,Is.EqualTo(newNumber));
            Assert.IsNull(updatedPhone.Address);
        }

        [Test]
        public void ShouldLoadExistingPhone()
        {
            var phone = phoneRepository.Load(savedPhone.Id);
           
            Assert.IsNotNull(phone);
            Assert.That(phone.Id,Is.EqualTo(savedPhone.Id));
        }

        [Test]
        public void ShouldDeleteExistingPhone()
        {
            phoneRepository.Delete(savedPhone.Id);

            var phone = phoneRepository.Load(savedPhone.Id);
            Assert.IsNull(phone);
        }

        [Test]
        public void ShouldLoadAllPhonesForConstituent()
        {
            testDataHelper.CreatePhone(PhoneMother.Mobile(savedConstituent));

            var phones = phoneRepository.LoadAll(savedConstituent);

            Assert.That(phones.Count,Is.EqualTo(2));
        }

        [Test]
        public void ShouldLoadAllPhonesForAnAddress()
        {
            testDataHelper.CreatePhone(PhoneMother.Mobile(savedConstituent,savedAddress));

            var phones = phoneRepository.LoadAll(savedAddress);

            Assert.That(phones.Count,Is.EqualTo(2));
        }
    }
}