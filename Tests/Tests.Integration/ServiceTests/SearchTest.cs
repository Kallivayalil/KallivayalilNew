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
            var uriString = string.Format(@"{0}?firstName={1}&lastName={2}&email={3}&phone={4}&occupationName={4}&occupationDescription={4}
                &instituteName={4}&instituteLocation={4}&qualification={4}&yearOfGradutation={4}", baseUri, "Agnes", "alba", string.Empty, null);
            var searchDatas = HttpHelper.Get<ConstituentsData>(uriString);

            Assert.IsNotNull(searchDatas);
            Assert.That(searchDatas.Count, Is.EqualTo(1));
        }
        
        [Test]
        public void ShouldGetConstituentWhenSearchingByEmail()
        {
            testDataHelper.CreateAddress(AddressMother.London(savedConstituent));
            var uriString = string.Format(@"{0}?firstName={1}&lastName={2}&email={3}&phone={4}
                &occupationName={4}&occupationDescription={4}&instituteName={4}&instituteLocation={4}&qualification={4}&yearOfGradutation={4}"
                , baseUri, "Agnes", "alba", "mary@franklin.com", null);
            var searchDatas = HttpHelper.Get<ConstituentsData>(uriString);

            Assert.IsNotNull(searchDatas);
            Assert.That(searchDatas.Count, Is.EqualTo(2));
        }

        [Test]
        public void ShouldGetOnlyOneConstituentWhenSearchingByEmailAndNameReturnsTheSameConstituent()
        {
            testDataHelper.CreateAddress(AddressMother.London(savedConstituent));
            var email = testDataHelper.CreateEmail(EmailMother.Official(savedConstituent));
            var uriString = string.Format(@"{0}?firstName={1}&lastName={2}&email={3}&phone={4}
                &occupationName={4}&occupationDescription={4}&instituteName={4}&instituteLocation={4}&qualification={4}&yearOfGradutation={4}"
                , baseUri, "Agnes", "alba", email.Address, null);
            var searchDatas = HttpHelper.Get<ConstituentsData>(uriString);

            Assert.IsNotNull(searchDatas);
            Assert.That(searchDatas.Count, Is.EqualTo(1));
        }
        [Test]
        public void ShouldGetConstituentWhenSearchingByPhone()
        {
            var phone = testDataHelper.CreatePhone(PhoneMother.Mobile(savedConstituent));
            var uriString = string.Format(@"{0}?firstName={1}&lastName={2}&email={3}&phone={4}
                    &occupationName={3}&occupationDescription={3}&instituteName={3}&instituteLocation={3}&qualification={3}&yearOfGradutation={3}"
                , baseUri, "Agnes", "alba", null, phone.Number);
            var searchDatas = HttpHelper.Get<ConstituentsData>(uriString);

            Assert.IsNotNull(searchDatas);
            Assert.That(searchDatas.Count, Is.EqualTo(1));
        }  
        
        [Test]
        public void ShouldGetConstituentWhenSearchingByOccupation()
        {
            var occupation = testDataHelper.CreateOccupation(OccupationMother.Engineer(savedConstituent));
            var uriString = string.Format(@"{0}?firstName={1}&lastName={2}&email={3}&phone={3}
                &occupationName={4}&occupationDescription={5}&instituteName={3}&instituteLocation={3}&qualification={3}&yearOfGradutation={3}"
                , baseUri, "Agnes", "alba", null, occupation.OccupationName, occupation.Description);
            var searchDatas = HttpHelper.Get<ConstituentsData>(uriString);

            Assert.IsNotNull(searchDatas);
            Assert.That(searchDatas.Count, Is.EqualTo(1));
        }


        [Test]
        public void ShouldGetConstituentWhenSearchingByEducationDetail()
        {
            var educationDetail = testDataHelper.CreateEducationDetail(EducationDetailMother.College(savedConstituent));
            var uriString = string.Format(@"{0}?firstName={1}&lastName={2}&email={3}&phone={3}
                   &occupationName={3}&occupationDescription={3}&instituteName={4}&instituteLocation={5}&qualification={6}&yearOfGradutation={7}"
                , baseUri, "Agnes", "alba", null, educationDetail.InstituteName, educationDetail.InstituteLocation,educationDetail.Qualification,educationDetail.YearOfGraduation);
            var searchDatas = HttpHelper.Get<ConstituentsData>(uriString);

            Assert.IsNotNull(searchDatas);
            Assert.That(searchDatas.Count, Is.EqualTo(1));
        }

        [Test]
        public void ShouldGetConstituentWhenSearchingByNameWithOneOfTheSearchValuesSet()
        {
            testDataHelper.CreateAddress(AddressMother.London(savedConstituent));
            var uriString = string.Format(@"{0}?firstName={1}&lastName={2}&email={1}&phone={1}
                &occupationName={1}&occupationDescription={1}&instituteName={1}&instituteLocation={1}&qualification={1}&yearOfGradutation={1}"
                , baseUri, null, "frank");
            var searchDatas = HttpHelper.Get<ConstituentsData>(uriString);

            Assert.IsNotNull(searchDatas);
            Assert.That(searchDatas.Count, Is.EqualTo(2));
        }


        [Test]
        public void ShouldNotGetAnyResultsWhenNoSearchValuesAreSent()
        {
            var uriString = string.Format(@"{0}?firstName={1}&lastName={1}&email={1}&phone={1}&occupationName={1}
                &occupationDescription={1}&instituteName={1}&instituteLocation={1}&qualification={1}&yearOfGradutation={1}", baseUri, null);
            var constituentsData = HttpHelper.Get<ConstituentsData>(uriString);

            Assert.IsNotNull(constituentsData);
            Assert.That(constituentsData.Count, Is.EqualTo(0));
        }



    }
}