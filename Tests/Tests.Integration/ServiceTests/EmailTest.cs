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
    public class EmailTest
    {
        private string baseUri = "http://localhost/kallivayalilService/KallivayalilService.svc/Emails";
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
            testDataHelper.HardDeleteEmails();
            testDataHelper.HardDeleteConstituents();
            testDataHelper.HardDeleteConstituentNames();
        }

        [Test]
        public void ShouldSaveEmail()
        {
            var savedEmail = HttpHelper.Post(string.Format("{0}?constituentId={1}", baseUri, constituent.Id), EmailDataMother.Official(constituent));

            Assert.IsNotNull(savedEmail);
            Assert.That(savedEmail.Id, Is.GreaterThan(0));
        }

        [Test]
        public void ShouldUpdateExistingEmail()
        {
            var email = testDataHelper.CreateEmail(EmailMother.Official(constituent));

            var emailData = EmailDataMother.Official(email);
            const string emailAddress = "james.f@k.com";
            emailData.Address = emailAddress;
            var updatedData = HttpHelper.Put(string.Format("{0}?constituentId={1}", baseUri, constituent.Id), emailData);

            Assert.That(updatedData.Address,Is.EqualTo(emailAddress));
        }

        [Test]
        public void ShouldLoadExitingEmail()
        {
            var email = testDataHelper.CreateEmail(EmailMother.Official(constituent));

            var emailData = HttpHelper.Get<EmailData>(string.Format("{0}/{1}", baseUri, email.Id));

            Assert.That(emailData.Id,Is.GreaterThan(0));
        }

        [Test]
        public void ShouldLoadAllEmails()
        {
            testDataHelper.CreateEmail(EmailMother.Official(constituent));
            testDataHelper.CreateEmail(EmailMother.Official(constituent));
            testDataHelper.CreateEmail(EmailMother.Official(constituent));

            var emailsData = HttpHelper.Get<EmailsData>(string.Format("{0}?constituentId={1}", baseUri, constituent.Id));

            Assert.That(emailsData.Count,Is.EqualTo(3));
        }

        [Test]
        public void ShouldDeleteExistingPhone()
        {
            var email = testDataHelper.CreateEmail(EmailMother.Official(constituent));

            HttpHelper.DoHttpDelete(string.Format("{0}/{1}", baseUri, email.Id));

            var emailData = HttpHelper.DoHttpGet(string.Format("{0}/{1}", baseUri, email.Id));
            Assert.That(emailData.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }
    }
}