using Kallivayalil.Client;
using Kallivayalil.Domain;
using NUnit.Framework;
using Tests.Common.Helpers;
using Tests.Common.Mothers;

namespace Tests.Integration.ServiceTests
{
    [TestFixture]
    public class SearchTest
    {
        private string baseUri = "http://localhost/kallivayalilService/KallivayalilService.svc/Search";
        private TestDataHelper testDataHelper;
        private Constituent savedConstituent;

        [SetUp]
        public void Setup()
        {
            testDataHelper = new TestDataHelper();
            savedConstituent = testDataHelper.CreateConstituent(ConstituentMother.ConstituentWithName(ConstituentNameMother.AgnesAlba()));
        }

        [TearDown]
        public void TearDown()
        {
            testDataHelper.HardDeleteAddress();
            testDataHelper.HardDeletePhones();
            testDataHelper.HardDeleteEmails();
            testDataHelper.HardDeleteOccupations();
            testDataHelper.HardDeleteEducationDetails();
            testDataHelper.HardDeleteConstituents();
            testDataHelper.HardDeleteConstituentNames();
        }

        [Test]
        public void ShouldSearchForConstituentByEmailId()
        {
            var uriString = string.Format("{0}?emailId={1}", "http://localhost/kallivayalilService/KallivayalilService.svc/Find", "james@franklin.com");
            var constituentData = HttpHelper.Get<ConstituentData>(uriString);

            Assert.IsNotNull(constituentData);
            Assert.That(constituentData.Id,Is.EqualTo(1));
        }

        [Test]
        public void ShouldGetConstituentWhenSearchingByName()
        {
            testDataHelper.CreateAddress(AddressMother.London(savedConstituent));
            var uriString = string.Format("{0}?firstName={1}&lastName={2}&email={3}&phone={4}&occupationName={5}&occupationDescription={6}", baseUri, "Agnes", "alba", string.Empty, null,null,null);
            var searchDatas = HttpHelper.Get<ConstituentsData>(uriString);

            Assert.IsNotNull(searchDatas);
            Assert.That(searchDatas.Count, Is.EqualTo(1));
        }
        
        [Test]
        public void ShouldGetConstituentWhenSearchingByEmail()
        {
            testDataHelper.CreateAddress(AddressMother.London(savedConstituent));
            var uriString = string.Format("{0}?firstName={1}&lastName={2}&email={3}&phone={4}&occupationName={5}&occupationDescription={6}", baseUri, "Agnes", "alba", "mary@franklin.com", null,null,null);
            var searchDatas = HttpHelper.Get<ConstituentsData>(uriString);

            Assert.IsNotNull(searchDatas);
            Assert.That(searchDatas.Count, Is.EqualTo(2));
        }

        [Test]
        public void ShouldGetOnlyOneConstituentWhenSearchingByEmailAndNameReturnsTheSameConstituent()
        {
            testDataHelper.CreateAddress(AddressMother.London(savedConstituent));
            var email = testDataHelper.CreateEmail(EmailMother.Official(savedConstituent));
            var uriString = string.Format("{0}?firstName={1}&lastName={2}&email={3}&phone={4}&occupationName={5}&occupationDescription={6}", baseUri, "Agnes", "alba", email.Address, null,null,null);
            var searchDatas = HttpHelper.Get<ConstituentsData>(uriString);

            Assert.IsNotNull(searchDatas);
            Assert.That(searchDatas.Count, Is.EqualTo(1));
        }
        [Test]
        public void ShouldGetConstituentWhenSearchingByPhone()
        {
            var phone = testDataHelper.CreatePhone(PhoneMother.Mobile(savedConstituent));
            var uriString = string.Format("{0}?firstName={1}&lastName={2}&email={3}&phone={4}&occupationName={5}&occupationDescription={6}", baseUri, "Agnes", "alba", null, phone.Number,null,null);
            var searchDatas = HttpHelper.Get<ConstituentsData>(uriString);

            Assert.IsNotNull(searchDatas);
            Assert.That(searchDatas.Count, Is.EqualTo(1));
        }  
        
        [Test]
        public void ShouldGetConstituentWhenSearchingByOccupation()
        {
            var occupation = testDataHelper.CreateOccupation(OccupationMother.Doctor(savedConstituent));
            var uriString = string.Format("{0}?firstName={1}&lastName={2}&email={3}&phone={4}&occupationName={5}&occupationDescription={6}"
                , baseUri, "Agnes", "alba", null, null, occupation.OccupationName, occupation.Description);
            var searchDatas = HttpHelper.Get<ConstituentsData>(uriString);

            Assert.IsNotNull(searchDatas);
            Assert.That(searchDatas.Count, Is.EqualTo(1));
        }

        [Test]
        public void ShouldGetConstituentWhenSearchingByNameWithOneOfTheSearchValuesSet()
        {
            testDataHelper.CreateAddress(AddressMother.London(savedConstituent));
            var uriString = string.Format("{0}?firstName={1}&lastName={2}&email={3}&phone={4}&occupationName={5}&occupationDescription={6}", baseUri, null, "frank", null, null,null,null);
            var searchDatas = HttpHelper.Get<ConstituentsData>(uriString);

            Assert.IsNotNull(searchDatas);
            Assert.That(searchDatas.Count, Is.EqualTo(2));
        }


        [Test]
        public void ShouldNotGetAnyResultsWhenNoSearchValuesAreSent()
        {
            var uriString = string.Format("{0}?firstName={1}&lastName={2}&email={3}&phone={4}&occupationName={5}&occupationDescription={6}", baseUri, null, null, null, null,null,null);
            var constituentsData = HttpHelper.Get<ConstituentsData>(uriString);

            Assert.IsNotNull(constituentsData);
            Assert.That(constituentsData.Count, Is.EqualTo(0));
        }



    }
}