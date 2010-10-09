using System;
using System.Net;
using Kallivayalil.Client;
using NUnit.Framework;

namespace Tests.Integration.ServiceTests
{
    [TestFixture]
    public class ConstituentTest
    {
        private string baseUri = "http://localhost/kallivayalilService/KallivayalilService.svc/Constituents";

        [Test]
        public void ShouldLoadConstituent()
        {
            var constituentData = HttpHelper.Get<ConstituentData>(string.Format("{0}/3",baseUri));
            Assert.IsNotNull(constituentData);
        }

        [Test]
        public void ShouldCreateConstituent()
        {
            var constituentData = new ConstituentData {Gender = "F", BornOn = DateTime.Now, BranchName = 1, MaritialStatus = 1, IsRegistered = false};
            var savedConstituent = HttpHelper.Post(baseUri,constituentData);

            Assert.IsNotNull(savedConstituent);
            Assert.That(savedConstituent.Id,Is.GreaterThan(0));
        }

        [Test]
        public void ShouldUpdateConstituent()
        {
            var constituentData = new ConstituentData { Gender = "F", BornOn = DateTime.Now, BranchName = 1, MaritialStatus = 1, IsRegistered = false };
            var savedConstituent = HttpHelper.Post(baseUri, constituentData);

            savedConstituent.Gender = "M";
            savedConstituent.BranchName = 3;
            savedConstituent.IsRegistered = true;
            
            var updatedConstituentData = HttpHelper.Put(string.Format("{0}/{1}", baseUri, savedConstituent.Id),savedConstituent);
            Assert.IsNotNull(updatedConstituentData);
            Assert.That(updatedConstituentData.Id, Is.EqualTo(savedConstituent.Id));
            Assert.That(updatedConstituentData.Gender, Is.EqualTo("M"));
            Assert.That(updatedConstituentData.BranchName, Is.EqualTo(3));
            Assert.That(updatedConstituentData.IsRegistered, Is.EqualTo(true));
        }

        [Test]
        public void ShouldDeleteExistingConstituent()
        {
            var constituentData = new ConstituentData { Gender = "F", BornOn = DateTime.Now, BranchName = 1, MaritialStatus = 1, IsRegistered = false };
            var savedConstituent = HttpHelper.Post(baseUri, constituentData);

            var response = HttpHelper.DoHttpDelete(string.Format("{0}/{1}", baseUri, savedConstituent.Id));
            
            Assert.That(response.StatusCode,Is.EqualTo(HttpStatusCode.OK));

//            var deletedData = HttpHelper.Get<ConstituentData>(string.Format("{0}/{1}", baseUri, savedConstituent.Id));
//            Assert.IsNull(deletedData);

        }

    }
}
