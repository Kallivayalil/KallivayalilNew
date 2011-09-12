using Kallivayalil.Client;
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

        [SetUp]
        public void Setup()
        {
            testDataHelper = new TestDataHelper();
            testDataHelper.CreateConstituent(ConstituentMother.ConstituentWithName(ConstituentNameMother.JessicaAlba()));
        }

        [TearDown]
        public void TearDown()
        {
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
        public void ShouldGetConstituentByName()
        {
            var uriString = string.Format("{0}?firstName={1}&lastName={2}", baseUri, "Jessica","alba");
            var searchDatas = HttpHelper.Get<SearchResultsData>(uriString);

            Assert.IsNotNull(searchDatas);
            Assert.That(searchDatas.Count, Is.EqualTo(2));
        }

        [Test]
        public void ShouldNotGetAnyResultsWhenNoSearchValuesAreSent()
        {
            var uriString = string.Format("{0}?firstName={1}&lastName={2}", baseUri, null,null);
            var searchDatas = HttpHelper.Get<SearchResultsData>(uriString);

            Assert.IsNotNull(searchDatas);
            Assert.That(searchDatas.Count, Is.EqualTo(0));
        }

//        [Test]
//        public void ShouldNotGetAnyResultsWhenNoSearchValuesAreSent()
//        {
//            var uriString = string.Format("{0}?firstName={1}&lastName={2}", baseUri, null,null);
//            var constituentsData = HttpHelper.Get<ConstituentsData>(uriString);
//
//            Assert.IsNotNull(constituentsData);
//            Assert.That(constituentsData.Count, Is.EqualTo(0));
//        }

    }
}