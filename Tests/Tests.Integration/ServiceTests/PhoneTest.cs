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
    public class PhoneTest
    {
        private string baseUri = "http://localhost/kallivayalilService/KallivayalilService.svc/Phones";
        private Constituent constituent;
        private TestDataHelper testDataHelper;
        private Address savedAddress;

        [SetUp]
        public void SetUp()
        {
            testDataHelper = new TestDataHelper();

            constituent = testDataHelper.CreateConstituent(ConstituentMother.ConstituentWithName(ConstituentNameMother.JamesFranklin()));
            savedAddress = testDataHelper.CreateAddress(AddressMother.SanFrancisco(constituent));
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
            var savedMobile = HttpHelper.Post(string.Format("{0}?constituentId={1}", baseUri, constituent.Id), PhoneDataMother.Mobile(constituent,savedAddress));

            Assert.IsNotNull(savedMobile);
            Assert.That(savedMobile.Id, Is.GreaterThan(0));
        }

        [Test]
        public void ShouldUpdateExistingPhone()
        {
            var phone = testDataHelper.CreatePhone(PhoneMother.Mobile(constituent, savedAddress));

            var phoneData = PhoneDataMother.Mobile(phone);
            const string number = "12345-12345";
            phoneData.Number = number;
            var updatedData = HttpHelper.Put(string.Format("{0}?constituentId={1}", baseUri, constituent.Id), phoneData);

            Assert.That(updatedData.Number,Is.EqualTo(number));
        }

        [Test]
        public void ShouldLoadExitingPhone()
        {
            var phone = testDataHelper.CreatePhone(PhoneMother.Mobile(constituent, savedAddress));

            var phoneData = HttpHelper.Get<PhoneData>(string.Format("{0}/{1}", baseUri, phone.Id));

            Assert.That(phoneData.Id,Is.GreaterThan(0));
        }

        [Test]
        public void ShouldLoadAllPhones()
        {
            testDataHelper.CreatePhone(PhoneMother.Mobile(constituent, savedAddress));
            testDataHelper.CreatePhone(PhoneMother.Mobile(constituent, savedAddress));
            testDataHelper.CreatePhone(PhoneMother.Mobile(constituent, savedAddress));

            var phonesData = HttpHelper.Get<PhonesData>(string.Format("{0}?constituentId={1}", baseUri, constituent.Id));

            Assert.That(phonesData.Count,Is.EqualTo(3));
        }

        [Test]
        public void ShouldDeleteExistingPhone()
        {
            var phone = testDataHelper.CreatePhone(PhoneMother.Mobile(constituent, savedAddress));

            HttpHelper.DoHttpDelete(string.Format("{0}/{1}", baseUri, phone.Id));

            var phoneData = HttpHelper.DoHttpGet(string.Format("{0}/{1}", baseUri, phone.Id));
            Assert.That(phoneData.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }
    }
}