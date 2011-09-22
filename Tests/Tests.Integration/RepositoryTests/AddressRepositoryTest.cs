using System.Linq;
using Kallivayalil.DataAccess.Repositories;
using Kallivayalil.Domain;
using NUnit.Framework;
using Tests.Common.Helpers;
using Tests.Common.Mothers;

namespace Tests.Integration.RepositoryTests
{
    [TestFixture]
    public class AddressRepositoryTest
    {
        private TestDataHelper testDataHelper;
        private Constituent savedConstituent;
        private Address savedAddress;
        private AddressRepository addressRepository;

        [SetUp]
        public void SetUp()
        {
            testDataHelper = new TestDataHelper();
            var constituent = ConstituentMother.ConstituentWithName(ConstituentNameMother.JamesFranklin());
            savedConstituent = testDataHelper.CreateConstituent(constituent);
            savedAddress = testDataHelper.CreateAddress(AddressMother.SanFrancisco(savedConstituent));

            addressRepository = new AddressRepository(testDataHelper.session);
        }

        [TearDown]
        public void TearDown()
        {
            testDataHelper.HardDeleteAddress();
            testDataHelper.HardDeleteConstituents();
            testDataHelper.HardDeleteConstituentNames();
        }

        [Test]
        public void ShouldSaveConstituentAddress()
        {
            var address = addressRepository.Save(AddressMother.SanFrancisco(savedConstituent));

            Assert.That(address.Id, Is.GreaterThan(0));
        }

        [Test]
        public void ShouldUpdateTheSavedConstituentAddress()
        {
            var london = AddressMother.London(savedConstituent);
            savedAddress.Line1 = london.Line1;
            savedAddress.City = london.City;
            savedAddress.Country = london.Country;
            savedAddress.PostCode = london.PostCode;

            Address updatedAddress = addressRepository.Update(savedAddress);

            Assert.That(updatedAddress.Line1, Is.EqualTo(london.Line1));
            Assert.That(updatedAddress.City, Is.EqualTo(london.City));
            Assert.That(updatedAddress.Country, Is.EqualTo(london.Country));
            Assert.That(updatedAddress.PostCode, Is.EqualTo(london.PostCode));
        }

        [Test]
        public void ShouldDeleteAnExistingAddress()
        {
            addressRepository.Delete(savedAddress.Id);

            var address = addressRepository.Get<Address>(savedAddress.Id);
            Assert.IsNull(address);
        }

        [Test]
        public void ShouldGetExistingAddress()
        {
            var address = addressRepository.Load(savedAddress.Id);

            Assert.IsNotNull(address);
            Assert.That(address.Country, Is.EqualTo(savedAddress.Country));
            Assert.That(address.Id, Is.EqualTo(savedAddress.Id));
        }

        [Test]
        public void ShouldGetAddressesForConstituent()
        {
            var london = testDataHelper.CreateAddress(AddressMother.London(savedConstituent));
            var secondConstituent = testDataHelper.CreateConstituent(ConstituentMother.ConstituentWithName(ConstituentNameMother.JamesFranklin()));
            testDataHelper.CreateAddress(AddressMother.SanFrancisco(secondConstituent));

            var addresses = addressRepository.LoadAll(savedConstituent.Id).ToList();

            Assert.That(addresses.Count, Is.EqualTo(2));
            Assert.That(addresses.Exists(address => address.Id.Equals(savedAddress.Id)));
            Assert.That(addresses.Exists(address => address.Id.Equals(london.Id)));
        }

        [Test]
        public void ShouldSearchForAddress()
        {
            var address = AddressMother.London(savedConstituent);
            var address1 = AddressMother.SanFrancisco((savedConstituent));
            
            testDataHelper.CreateAddress(address);
            testDataHelper.CreateAddress(address1);

            var phones = addressRepository.SearchAddressBy("Montgomery", "London", "California", "USA", "ABCD", false);

            Assert.That(phones.Count, Is.EqualTo(3));
        }  
        
        [Test]
        public void ShouldSearchForAddressMatchAllCriteria()
        {
            var address = AddressMother.London(savedConstituent);
            var address1 = AddressMother.SanFrancisco((savedConstituent));
            
            testDataHelper.CreateAddress(address);
            testDataHelper.CreateAddress(address1);

            var phones = addressRepository.SearchAddressBy(address.Line1, address.State, address.City, address.Country, address.PostCode, true);

            Assert.That(phones.Count, Is.EqualTo(1));
        }
    }
}