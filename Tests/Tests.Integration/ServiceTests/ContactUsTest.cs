using Kallivayalil.Client;
using NUnit.Framework;
using Tests.Common.Helpers;

namespace Tests.Integration.ServiceTests
{
    [TestFixture]
    public class ContactUsTest
    {
        private string baseUri = "http://localhost/kallivayalilService/KallivayalilService.svc/ContactUs";
        private TestDataHelper testDataHelper;

        [SetUp]
        public void SetUp()
        {
            testDataHelper = new TestDataHelper();

        }

        [TearDown]
        public void TearDown()
        {
            testDataHelper.HardDeleteContactUs();
        }


        [Test]
        public void ShouldSaveFeedback()
        {
            var savedContactUs = HttpHelper.Post(string.Format("{0}", baseUri), new ContactUsData(){Name = "tetst",Email = "test@test.com",Comments = "test"});

            Assert.IsNotNull(savedContactUs);
            Assert.That(savedContactUs.Id, Is.GreaterThan(0));
        }
    }
}