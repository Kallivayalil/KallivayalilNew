using Kallivayalil.DataAccess.Repositories;
using Kallivayalil.Domain;
using NUnit.Framework;
using Tests.Common.Helpers;
using Tests.Common.Mothers;

namespace Tests.Integration.RepositoryTests
{
    [TestFixture]
    public class UploadFileRepositoryTest
    {
        private TestDataHelper testDataHelper;
        private UploadFileRepository uploadFileRepository;
        private Upload savedUpload;
        private Constituent constituent;

        [SetUp]
        public void SetUp()
        {
            testDataHelper = new TestDataHelper();
            uploadFileRepository = new UploadFileRepository();
            constituent = testDataHelper.CreateConstituent(ConstituentMother.ConstituentWithName(ConstituentNameMother.JamesFranklin()));
            savedUpload = testDataHelper.CreateUpload(UploadMother.Test(constituent));
        }

        [TearDown]
        public void TearDown()
        {
            testDataHelper.HardDeleteUpload();
        }

        [Test]
        public void ShouldSaveFileInfo()
        {
            var savedFileInfo = uploadFileRepository.Save(UploadMother.Test(constituent));
            Assert.That(savedFileInfo.Id, Is.GreaterThan(0));
        }

        [Test]
        public void ShouldLoadExistingFileInfo()
        {
            var fileInfo = uploadFileRepository.Load(savedUpload.Id);

            Assert.IsNotNull(fileInfo);
            Assert.That(fileInfo.Id, Is.EqualTo(savedUpload.Id));
        }
  
        [Test]
        public void ShouldLoadAllFileInfo()
        {
            testDataHelper.CreateUpload(UploadMother.Test(constituent));
            testDataHelper.CreateUpload(UploadMother.Test(constituent));
            testDataHelper.CreateUpload(UploadMother.Test(constituent));

            var fileInfos = uploadFileRepository.LoadAll();

            Assert.IsNotNull(fileInfos);
            Assert.That(fileInfos.Count, Is.EqualTo(4));
        }

        [Test]
        public void ShouldDeleteExistingFeedback()
        {
            uploadFileRepository.Delete(savedUpload.Id);

            var feedback = uploadFileRepository.Load(savedUpload.Id);
            Assert.IsNull(feedback);
        }


    }
}