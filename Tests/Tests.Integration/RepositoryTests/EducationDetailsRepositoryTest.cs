using Kallivayalil.DataAccess.Repositories;
using Kallivayalil.Domain;
using NUnit.Framework;
using Tests.Common.Helpers;
using Tests.Common.Mothers;

namespace Tests.Integration.RepositoryTests
{
    [TestFixture]
    public class EducationDetailsRepositoryTest
    {
        private TestDataHelper testDataHelper;
        private Constituent savedConstituent;
        private EducationDetailRepository educationDetailRepository;
        private EducationDetail savedEducationalDetail;

        [SetUp]
        public void SetUp()
        {
            testDataHelper = new TestDataHelper();
            var constituent = ConstituentMother.ConstituentWithName(ConstituentNameMother.JamesFranklin());
            savedConstituent = testDataHelper.CreateConstituent(constituent);
            educationDetailRepository = new EducationDetailRepository(testDataHelper.session);
            savedEducationalDetail = testDataHelper.CreateEducationDetail(EducationDetailMother.School(savedConstituent));
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
            var educationDetail = educationDetailRepository.Save(EducationDetailMother.School(savedConstituent));

            Assert.That(educationDetail.Id, Is.GreaterThan(0));
        }


        [Test]
        public void ShouldUpdateExistingEducationalDetail()
        {
            const string newInstituteLocation = "Salem District";
            const string newInstituteName = "Montfort";
            const string newQualification = "12th grade";

            savedEducationalDetail.InstituteLocation = newInstituteLocation;
            savedEducationalDetail.InstituteName = newInstituteName;
            savedEducationalDetail.Qualification = newQualification;

            var updatedEducationDetail = educationDetailRepository.Update(savedEducationalDetail);
            Assert.That(updatedEducationDetail.InstituteLocation, Is.EqualTo(newInstituteLocation));
            Assert.That(updatedEducationDetail.InstituteName, Is.EqualTo(newInstituteName));
            Assert.That(updatedEducationDetail.Qualification, Is.EqualTo(newQualification));
        }

        [Test]
        public void ShouldLoadExistingEducationDetail()
        {
            var educationDetail = educationDetailRepository.Load(savedEducationalDetail.Id);

            Assert.IsNotNull(educationDetail);

            Assert.That(educationDetail.Id, Is.EqualTo(savedEducationalDetail.Id));
        }

        [Test]
        public void ShouldDeleteExistingEducationDetail()
        {
            educationDetailRepository.Delete(savedEducationalDetail.Id);

            var educationDetail = educationDetailRepository.Load(savedEducationalDetail.Id);
            Assert.IsNull(educationDetail);
        }

        [Test]
        public void ShouldLoadAllEducationDetailsForConstituent()
        {
            testDataHelper.CreateEducationDetail(EducationDetailMother.School(savedConstituent));

            var educationDetails = educationDetailRepository.LoadAll(savedConstituent);

            Assert.That(educationDetails.Count, Is.EqualTo(2));
        }
    }
}