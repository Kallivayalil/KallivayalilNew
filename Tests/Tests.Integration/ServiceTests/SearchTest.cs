using Kallivayalil.Client;
using Kallivayalil.Domain;
using NUnit.Framework;
using Tests.Common.Helpers;
using Tests.Common.Mothers;
using System.Linq;

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
            var constituentWithName = ConstituentMother.ConstituentWithName(ConstituentNameMother.AgnesAlba());
            constituentWithName.BranchName = BranchTypeMother.Anavalaril();
            constituentWithName.HouseName = "xyz";
            savedConstituent = testDataHelper.CreateConstituent(constituentWithName);
        }

        [TearDown]
        public void TearDown()
        {
            testDataHelper.HardDeletePhones();
            testDataHelper.HardDeleteAddress();
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
        public void ShouldSearchForConstituentGivenId()
        {
            var registeredConstituent = testDataHelper.CreateConstituent(ConstituentMother.ConstituentWithName(ConstituentNameMother.JamesFranklin(), 'A'));
            var address = testDataHelper.CreateAddress(AddressMother.London(registeredConstituent));
            testDataHelper.CreatePhone(PhoneMother.Mobile(registeredConstituent, address));
            testDataHelper.CreateEmail(EmailMother.Official(registeredConstituent));
            testDataHelper.CreateConstituent(ConstituentMother.ConstituentWithName(ConstituentNameMother.JamesFranklin(), 'R'));

            var uriString = string.Format("{0}?constituentId={1}", "http://localhost/kallivayalilService/KallivayalilService.svc/SearchUnRegistered", registeredConstituent.Id);
            var constituentsData = HttpHelper.Get<ConstituentsData>(uriString);

            var constituentData = constituentsData.First();
            Assert.IsNotNull(constituentData);
            Assert.That(constituentData.Id,Is.EqualTo(1));
        }

        [Test]
        public void ShouldGetConstituentWhenSearchingByName()
        {
            testDataHelper.CreateAddress(AddressMother.London(savedConstituent));
            var uriString = string.Format(@"{0}?firstName={1}&lastName={2}&email={3}&phone={4}
                &occupationName={4}&occupationDescription={4}
                &instituteName={4}&instituteLocation={4}&qualification={4}&yearOfGradutation={4}
                &address={4}&state={4}&city={4}&country={4}&postcode={4}
                &preferedName={5}&houseName={4}&branch={4}&matchAllCriteria={6}"
                , baseUri, "Agnes", "alba", string.Empty, null,"agnes",false);
            var searchDatas = HttpHelper.Get<ConstituentsData>(uriString);

            Assert.IsNotNull(searchDatas);
            Assert.That(searchDatas.Count, Is.EqualTo(1));
        }

        [Test]
        public void ShouldGetConstituentWhenSearchingByBranchAndHouseName()
        {
            var uriString = string.Format(@"{0}?firstName={4}&lastName={3}&email={4}&phone={4}&occupationName={4}&occupationDescription={4}&instituteName={4}&instituteLocation={4}&qualification={4}&yearOfGradutation={4}&address={4}&state={4}&city={4}&country={4}&postcode={4}&preferedName={4}&houseName={1}&branch={2}&matchAllCriteria={5}"
                , baseUri, "xyz", "Anavalaril", null,null,false);
            var searchDatas = HttpHelper.Get<ConstituentsData>(uriString);

            Assert.IsNotNull(searchDatas);
            Assert.That(searchDatas.Count, Is.EqualTo(1));
        } 
        
        [Test]
        public void ShouldGetConstituentWhenSearchingByBranchAndHouseNameMatchAllCriteria()
        {
            var uriString = string.Format(@"{0}?firstName={4}&lastName={3}&email={4}&phone={4}&occupationName={4}&occupationDescription={4}&instituteName={4}&instituteLocation={4}&qualification={4}&yearOfGradutation={4}&address={4}&state={4}&city={4}&country={4}&postcode={4}&preferedName={4}&houseName={1}&branch={2}&matchAllCriteria={5}"
                , baseUri, "xyz1", "Anavalaril", null,null,true);
            var searchDatas = HttpHelper.Get<ConstituentsData>(uriString);

            Assert.IsNotNull(searchDatas);
            Assert.That(searchDatas.Count, Is.EqualTo(0));
        }

        [Test]
        public void ShouldGetConstituentWhenSearchingByEmail()
        {
            testDataHelper.CreateAddress(AddressMother.London(savedConstituent));
            var uriString = string.Format(@"{0}?firstName={1}&lastName={2}&email={3}&phone={4}
                &occupationName={4}&occupationDescription={4}
                &instituteName={4}&instituteLocation={4}&qualification={4}&yearOfGradutation={4}
                &address={4}&state={4}&city={4}&country={4}&postcode={4}
                &preferedName={4}&houseName={4}&branch={4}&matchAllCriteria={5}"
                , baseUri, "Agnes", "alba", "mary@franklin.com", null,false);
            var searchDatas = HttpHelper.Get<ConstituentsData>(uriString);

            Assert.IsNotNull(searchDatas);
            Assert.That(searchDatas.Count, Is.EqualTo(2));
        }
        
        [Test]
        public void ShouldGetConstituentWhenSearchingByEmailMatchAllCriteria()
        {
             var email = testDataHelper.CreateEmail(EmailMother.Official(savedConstituent));
            var uriString = string.Format(@"{0}?firstName={1}&lastName={2}&email={3}&phone={4}&occupationName={4}&occupationDescription={4}&instituteName={4}&instituteLocation={4}&qualification={4}&yearOfGradutation={4}&address={4}&state={4}&city={4}&country={4}&postcode={4}&preferedName={4}&houseName={4}&branch={4}&matchAllCriteria={5}"
                , baseUri, savedConstituent.Name.FirstName, savedConstituent.Name.LastName, email.Address, null, true);
            var searchDatas = HttpHelper.Get<ConstituentsData>(uriString);

            Assert.IsNotNull(searchDatas);
            Assert.That(searchDatas.Count, Is.EqualTo(1));
        }

        [Test]
        public void ShouldGetOnlyOneConstituentWhenSearchingByEmailAndNameReturnsTheSameConstituent()
        {
            testDataHelper.CreateAddress(AddressMother.London(savedConstituent));
            var email = testDataHelper.CreateEmail(EmailMother.Official(savedConstituent));
            var uriString = string.Format(@"{0}?firstName={1}&lastName={2}&email={3}&phone={4}
                &occupationName={4}&occupationDescription={4}
                &instituteName={4}&instituteLocation={4}&qualification={4}&yearOfGradutation={4}
                &address={4}&state={4}&city={4}&country={4}&postcode={4}
                &preferedName={4}&houseName={4}&branch={4}&matchAllCriteria={5}"
                , baseUri, "Agnes", "alba", email.Address, null,false);
            var searchDatas = HttpHelper.Get<ConstituentsData>(uriString);

            Assert.IsNotNull(searchDatas);
            Assert.That(searchDatas.Count, Is.EqualTo(1));
        }
        [Test]
        public void ShouldGetConstituentWhenSearchingByPhone()
        {
            var phone = testDataHelper.CreatePhone(PhoneMother.Mobile(savedConstituent));
            var uriString = string.Format(@"{0}?firstName={1}&lastName={2}&email={3}&phone={4}
                    &occupationName={3}&occupationDescription={3}&instituteName={3}
                    &instituteLocation={3}&qualification={3}&yearOfGradutation={3}
                    &address={3}&state={3}&city={3}&country={3}&postcode={3}
                    &preferedName={3}&houseName={3}&branch={3}&matchAllCriteria={5}"
                , baseUri, "Agnes", "alba", null, phone.Number,false);
            var searchDatas = HttpHelper.Get<ConstituentsData>(uriString);

            Assert.IsNotNull(searchDatas);
            Assert.That(searchDatas.Count, Is.EqualTo(1));
        }  
        
        [Test]
        public void ShouldGetConstituentWhenSearchingByOccupation()
        {
            var occupation = testDataHelper.CreateOccupation(OccupationMother.Engineer(savedConstituent));
            var uriString = string.Format(@"{0}?firstName={1}&lastName={2}&email={3}&phone={3}
                &occupationName={4}&occupationDescription={5}
                &instituteName={3}&instituteLocation={3}&qualification={3}&yearOfGradutation={3}
                &address={3}&state={3}&city={3}&country={3}&postcode={3}
                &preferedName={3}&houseName={3}&branch={3}&matchAllCriteria={6}"
                , baseUri, "Agnes", "alba", null, occupation.OccupationName, occupation.Description,false);
            var searchDatas = HttpHelper.Get<ConstituentsData>(uriString);

            Assert.IsNotNull(searchDatas);
            Assert.That(searchDatas.Count, Is.EqualTo(1));
        }
        
        
        [Test]
        public void ShouldGetConstituentWhenSearchingByAddress()
        {
            var address = testDataHelper.CreateAddress(AddressMother.Texas(savedConstituent));
            var uriString = string.Format(@"{0}?firstName={1}&lastName={2}&email={3}&phone={3}
                &occupationName={3}&occupationDescription={3}
                &instituteName={3}&instituteLocation={3}&qualification={3}&yearOfGradutation={3}
                &address={4}&state={5}&city={6}&country={7}&postcode={8}
                &preferedName={3}&houseName={3}&branch={3}&matchAllCriteria={9}"
                , baseUri, "Agnes", "alba", null, address.Line1, address.State,address.City,address.Country,address.PostCode,false);
            var searchDatas = HttpHelper.Get<ConstituentsData>(uriString);

            Assert.IsNotNull(searchDatas);
            Assert.That(searchDatas.Count, Is.EqualTo(1));
        }


        [Test]
        public void ShouldGetConstituentWhenSearchingByEducationDetail()
        {
            var educationDetail = testDataHelper.CreateEducationDetail(EducationDetailMother.College(savedConstituent));
            var uriString = string.Format(@"{0}?firstName={1}&lastName={2}&email={3}&phone={3}
                   &occupationName={3}&occupationDescription={3}
                   &instituteName={4}&instituteLocation={5}&qualification={6}&yearOfGradutation={7}
                   &address={3}&state={3}&city={3}&country={3}&postcode={3}
                   &preferedName={3}&houseName={3}&branch={3}&matchAllCriteria={8}"
                , baseUri, "Agnes", "alba", null, educationDetail.InstituteName, educationDetail.InstituteLocation,educationDetail.Qualification,educationDetail.YearOfGraduation,false);
            var searchDatas = HttpHelper.Get<ConstituentsData>(uriString);

            Assert.IsNotNull(searchDatas);
            Assert.That(searchDatas.Count, Is.EqualTo(1));
        }

        [Test]
        public void ShouldGetConstituentWhenSearchingByNameWithOneOfTheSearchValuesSet()
        {
            testDataHelper.CreateAddress(AddressMother.London(savedConstituent));
            var uriString = string.Format(@"{0}?firstName={1}&lastName={2}&email={1}&phone={1}
                &occupationName={1}&occupationDescription={1}
                &instituteName={1}&instituteLocation={1}&qualification={1}&yearOfGradutation={1}
                &address={1}&state={1}&city={1}&country={1}&postcode={1}
                &preferedName={1}&houseName={1}&branch={1}&matchAllCriteria={3}"
                , baseUri, null, "frank",false);
            var searchDatas = HttpHelper.Get<ConstituentsData>(uriString);

            Assert.IsNotNull(searchDatas);
            Assert.That(searchDatas.Count, Is.EqualTo(2));
        }


        [Test]
        public void ShouldNotGetAnyResultsWhenNoSearchValuesAreSent()
        {
            var uriString = string.Format(@"{0}?firstName={1}&lastName={1}&email={1}&phone={1}&occupationName={1}
                &occupationDescription={1}
                &instituteName={1}&instituteLocation={1}&qualification={1}&yearOfGradutation={1}
                &address={1}&state={1}&city={1}&country={1}&postcode={1}
                &preferedName={1}&houseName={1}&branch={1}&matchAllCriteria={2}", baseUri, null,false);
            var constituentsData = HttpHelper.Get<ConstituentsData>(uriString);

            Assert.IsNotNull(constituentsData);
            Assert.That(constituentsData.Count, Is.EqualTo(0));
        }



    }
}