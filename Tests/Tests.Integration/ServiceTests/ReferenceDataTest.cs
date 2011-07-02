using System.Net;
using Kallivayalil.Client;
using NUnit.Framework;
using Tests.Common.Mothers;
using Tests.Integration.Mothers;

namespace Tests.Integration.ServiceTests
{
    [TestFixture]
    public class ReferenceDataTest
    {
        private const string BaseUri = "http://localhost/kallivayalilService/KallivayalilService.svc";

        [Test]
        public void ShouldLoadAllPhoneTypes()
        {

            var phonesData = HttpHelper.Get<PhoneTypesData>(string.Format("{0}/{1}", BaseUri,"PhoneTypes"));

            Assert.That(phonesData.Count,Is.EqualTo(2));
        }

        [Test]
        public void ShouldLoadAllEmailTypes()
        {

            var emailTypesData = HttpHelper.Get<EmailTypesData>(string.Format("{0}/{1}", BaseUri,"EmailTypes"));

            Assert.That(emailTypesData.Count,Is.EqualTo(2));
        }

    }
}