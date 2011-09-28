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
    public class UploadFileTest
    {
        private string baseUri = "http://localhost/kallivayalilService/KallivayalilService.svc/UploadFiles";
        private TestDataHelper testDataHelper;
        private Constituent constituent1;

        [SetUp]
        public void SetUp()
        {
            testDataHelper = new TestDataHelper();

            constituent1 = testDataHelper.CreateConstituent(ConstituentMother.ConstituentWithName(ConstituentNameMother.JamesFranklin()));

            testDataHelper.CreateUpload(UploadMother.Test(constituent1));
        }

        [TearDown]
        public void TearDown()
        {
            testDataHelper.HardDeleteUpload();
            testDataHelper.HardDeleteConstituents();
            testDataHelper.HardDeleteConstituentNames();
        }

        [Test]
        public void ShouldSaveFile()
        {
            var savedUpload = HttpHelper.Post(string.Format("{0}", baseUri), UploadDataMother.Test(constituent1));

            Assert.IsNotNull(savedUpload);
            Assert.That(savedUpload.Id, Is.GreaterThan(0));
        }

        [Test]
        public void ShouldUpdateExistingUpload()
        {
            var upload = testDataHelper.CreateUpload(UploadMother.Test(constituent1));

            var uploadData = UploadDataMother.Test(upload);
            var newName = "test 1";
            uploadData.Name = newName;
            var updatedData = HttpHelper.Put(string.Format("{0}/{1}", baseUri, upload.Id), uploadData);

            Assert.That(updatedData.Name, Is.EqualTo(newName));
        }

        [Test]
        public void ShouldLoadExitingUpload()
        {
            var upload = testDataHelper.CreateUpload(UploadMother.Test(constituent1));

            var uploadData = HttpHelper.Get<UploadData>(string.Format("{0}/{1}", baseUri, upload.Id));

            Assert.That(uploadData.Id, Is.GreaterThan(0));
        }

        [Test]
        public void ShouldLoadAllUloadFiles()
        {
            testDataHelper.CreateUpload(UploadMother.Test(constituent1));
            testDataHelper.CreateUpload(UploadMother.Test(constituent1));
            testDataHelper.CreateUpload(UploadMother.Test(constituent1));


            var uploadData = HttpHelper.Get<UploadDatas>(string.Format("{0}", baseUri));

            Assert.That(uploadData.Count, Is.EqualTo(4));
        }

        [Test]
        public void ShouldDeleteExistingCommittee()
        {
            var upload = testDataHelper.CreateUpload(UploadMother.Test(constituent1));

            HttpHelper.DoHttpDelete(string.Format("{0}/{1}", baseUri, upload.Id));

            var committeeData = HttpHelper.DoHttpGet(string.Format("{0}/{1}", baseUri, upload.Id));
            Assert.That(committeeData.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }
    }
}