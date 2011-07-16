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
    public class OccupationTest
    {
        private string baseUri = "http://localhost/kallivayalilService/KallivayalilService.svc/Occupations";
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
            testDataHelper.HardDeleteOccupations();
            testDataHelper.HardDeleteAddress();
            testDataHelper.HardDeleteConstituents();
            testDataHelper.HardDeleteConstituentNames();
        }



        [Test]
        public void ShouldSaveOccupation()
        {
            var savedOccupation = HttpHelper.Post(string.Format("{0}?constituentId={1}", baseUri, constituent.Id), OccupationDataMother.Doctor(constituent,savedAddress));

            Assert.IsNotNull(savedOccupation);
            Assert.That(savedOccupation.Id, Is.GreaterThan(0));
        }

        [Test]
        public void ShouldUpdateExistingOccupation()
        {
            var occupation = testDataHelper.CreateOccupation(OccupationMother.Doctor(constituent,savedAddress));

            var occupationData = OccupationDataMother.Doctor(constituent,savedAddress);
            const string occupationName = "Lawyer";
            occupationData.OccupationName = occupationName;
            var updatedData = HttpHelper.Put(string.Format("{0}/{1}", baseUri, occupation.Id), occupationData);

            Assert.That(updatedData.OccupationName,Is.EqualTo(occupationName));
        }

        [Test]
        public void ShouldLoadExitingOccupation()
        {
            var occupation = testDataHelper.CreateOccupation(OccupationMother.Doctor(constituent, savedAddress));

            var occupationData = HttpHelper.Get<OccupationData>(string.Format("{0}/{1}", baseUri, occupation.Id));

            Assert.That(occupationData.Id,Is.GreaterThan(0));
        }

        [Test]
        public void ShouldLoadAllOccupations()
        {
            testDataHelper.CreateOccupation(OccupationMother.Doctor(constituent, savedAddress));
            testDataHelper.CreateOccupation(OccupationMother.Doctor(constituent, savedAddress));
            testDataHelper.CreateOccupation(OccupationMother.Doctor(constituent, savedAddress));

            var occupationsData = HttpHelper.Get<OccupationsData>(string.Format("{0}?constituentId={1}", baseUri, constituent.Id));

            Assert.That(occupationsData.Count,Is.EqualTo(3));
        }

        [Test]
        public void ShouldDeleteExistingOccupation()
        {
            var occupation = testDataHelper.CreateOccupation(OccupationMother.Doctor(constituent, savedAddress));

            HttpHelper.DoHttpDelete(string.Format("{0}/{1}", baseUri, occupation.Id));

            var occupationData = HttpHelper.DoHttpGet(string.Format("{0}/{1}", baseUri, occupation.Id));
            Assert.That(occupationData.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }
    }
}