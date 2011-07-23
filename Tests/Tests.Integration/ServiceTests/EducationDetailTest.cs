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
    public class EducationDetailTest
    {
        private string baseUri = "http://localhost/kallivayalilService/KallivayalilService.svc/EducationDetails";
        private Constituent constituent;
        private TestDataHelper testDataHelper;

        [SetUp]
        public void SetUp()
        {
            testDataHelper = new TestDataHelper();

            constituent = testDataHelper.CreateConstituent(ConstituentMother.ConstituentWithName(ConstituentNameMother.JamesFranklin()));
        }

        [TearDown]
        public void TearDown()
        {
            testDataHelper.HardDeleteEducationDetails();
            testDataHelper.HardDeleteConstituents();
            testDataHelper.HardDeleteConstituentNames();
        }


        [Test]
        public void ShouldSaveEducationDetail()
        {
            var savedSchool = HttpHelper.Post(string.Format("{0}?constituentId={1}", baseUri, constituent.Id), EducationDetailDataMother.School(constituent));

            Assert.IsNotNull(savedSchool);
            Assert.That(savedSchool.Id, Is.GreaterThan(0));
        }

        [Test]
        public void ShouldUpdateExistingEducationDetail()
        {
            var educationDetail = testDataHelper.CreateEducationDetail(EducationDetailMother.School(constituent));

            var educationDetailData = EducationDetailDataMother.School(educationDetail);
            const string qualification = "10th grade";
            educationDetailData.Qualification = qualification;
            var updatedData = HttpHelper.Put(string.Format("{0}/{1}", baseUri, educationDetail.Id), educationDetailData);

            Assert.That(updatedData.Qualification,Is.EqualTo(qualification));
        }

        [Test]
        public void ShouldLoadExitingEducationDetail()
        {
            var educationDetail = testDataHelper.CreateEducationDetail(EducationDetailMother.School(constituent));

            var educationDetailData = HttpHelper.Get<EducationDetailData>(string.Format("{0}/{1}", baseUri, educationDetail.Id));

            Assert.That(educationDetailData.Id,Is.GreaterThan(0));
        }

        [Test]
        public void ShouldLoadAllEducationDetails()
        {
            testDataHelper.CreateEducationDetail(EducationDetailMother.School(constituent));
            testDataHelper.CreateEducationDetail(EducationDetailMother.School(constituent));
            testDataHelper.CreateEducationDetail(EducationDetailMother.School(constituent));

            var educationDetailsData = HttpHelper.Get<EducationDetailsData>(string.Format("{0}?constituentId={1}", baseUri, constituent.Id));

            Assert.That(educationDetailsData.Count,Is.EqualTo(3));
        }

        [Test]
        public void ShouldDeleteExistingEducationDetail()
        {
            var educationDetail = testDataHelper.CreateEducationDetail(EducationDetailMother.School(constituent));

            HttpHelper.DoHttpDelete(string.Format("{0}/{1}", baseUri, educationDetail.Id));

            var educationDetailData = HttpHelper.DoHttpGet(string.Format("{0}/{1}", baseUri, educationDetail.Id));

            Assert.That(educationDetailData.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }
    }
}