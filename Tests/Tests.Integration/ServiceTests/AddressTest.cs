using System.Net;
using Kallivayalil.Client;
using Kallivayalil.Common;
using Kallivayalil.Domain;
using NUnit.Framework;
using Tests.Common.Helpers;
using Tests.Common.Mothers;
using Tests.Integration.Mothers;

namespace Tests.Integration.ServiceTests
{
    [TestFixture]
    public class AddressTest
    {
        private string baseUri = "http://localhost/kallivayalilService/KallivayalilService.svc/Addresses";
        private Constituent constituent;
        private TestDataHelper testDataHelper;
        private Address savedAddress;

        [SetUp]
        public void SetUp()
        {
            testDataHelper = new TestDataHelper();

            constituent = testDataHelper.CreateConstituent(ConstituentMother.ConstituentWithName());
            savedAddress = testDataHelper.CreateAddress(AddressMother.SanFrancisco(constituent));
        }

        [Test]
        public void ShouldSaveConstituentAddress()
        {
            var savedSanFrancisco = HttpHelper.Post(string.Format("{0}?constituentId={1}", baseUri, constituent.Id), AddressDataMother.SanFrancisco(constituent));

            Assert.IsNotNull(savedSanFrancisco);
            Assert.That(savedSanFrancisco.Id, Is.GreaterThan(0));
        }

        [Test]
        public void ShouldUpdateExistingConstituentAddress()
        {
            var london = AddressDataMother.London(constituent);
            savedAddress.City = london.City;
            savedAddress.Country = london.Country;
            savedAddress.State = london.State;
            savedAddress.Type = london.Type;
            savedAddress.Line1 = london.Line1;
            savedAddress.PostCode = london.PostCode;

            var londonAddress = new AddressData();
            var mapper = new AutoDataContractMapper();
            mapper.Map(savedAddress,londonAddress);

            var updatedAddress = HttpHelper.Put(string.Format("{0}/{1}",baseUri,londonAddress.Id), londonAddress);

            Assert.That(updatedAddress.City,Is.EqualTo(savedAddress.City));
            Assert.That(updatedAddress.Id,Is.EqualTo(savedAddress.Id));
        }

        [Test]
        public void ShouldDeleteAnExistingConstituentAddress()
        {
            var response = HttpHelper.DoHttpDelete(string.Format("{0}/{1}", baseUri, savedAddress.Id));
            Assert.That(response.StatusCode,Is.EqualTo(HttpStatusCode.OK));

            var addressData = HttpHelper.DoHttpGet(string.Format("{0}/{1}", baseUri, savedAddress.Id));
            Assert.That(addressData.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));

        } 
        
        [Test]
        public void ShoulGetAnExistingConstituentAddress()
        {
            var addressData = HttpHelper.Get<AddressData>(string.Format("{0}/{1}", baseUri, savedAddress.Id));
            Assert.That(addressData.Line1,Is.EqualTo(savedAddress.Line1));
            Assert.That(addressData.Line2,Is.EqualTo(savedAddress.Line2));
            Assert.That(addressData.City,Is.EqualTo(savedAddress.City));
            Assert.That(addressData.State,Is.EqualTo(savedAddress.State));
            Assert.That(addressData.Country,Is.EqualTo(savedAddress.Country));
        }

        [Test]
        public void ShouldGetAllAddressesForAConstituent()
        {
            var london = testDataHelper.CreateAddress(AddressMother.London(constituent));

            AddressesData addressesData = HttpHelper.Get<AddressesData>(string.Format("{0}?constituentId={1}", baseUri, constituent.Id));

            Assert.That(addressesData.Count,Is.EqualTo(2));
            Assert.That(addressesData.Exists(data => data.Id.Equals(london.Id)));
            Assert.That(addressesData.Exists(data => data.Id.Equals(savedAddress.Id)));
        }
    }
   
}