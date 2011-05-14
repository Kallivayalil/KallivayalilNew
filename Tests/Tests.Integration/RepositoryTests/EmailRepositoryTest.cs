using Kallivayalil.DataAccess.Repositories;
using Kallivayalil.Domain;
using NUnit.Framework;
using Tests.Common.Helpers;
using Tests.Common.Mothers;

namespace Tests.Integration.RepositoryTests
{
    [TestFixture]
    public class EmailRepositoryTest
    {
        private TestDataHelper testDataHelper;
        private Constituent savedConstituent;
        private EmailRepository emailRepository;
        private Email savedEmail;

        [SetUp]
        public void SetUp()
        {
            testDataHelper = new TestDataHelper();
            emailRepository = new EmailRepository(testDataHelper.session);
            var constituent = ConstituentMother.ConstituentWithName(ConstituentNameMother.JamesFranklin());
            savedConstituent = testDataHelper.CreateConstituent(constituent);
            savedEmail = testDataHelper.CreateEmail(EmailMother.Official(savedConstituent));
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
            var email = emailRepository.Save(EmailMother.Official(savedConstituent));

            Assert.That(email.Id,Is.GreaterThan(0));
        }

        [Test]
        public void ShouldUpdateExistingEmail()
        {
            const string newEmail = "a@b.com";
            savedEmail.Address = newEmail;
            var updatedEmail = emailRepository.Update(savedEmail);

            Assert.That(updatedEmail.Address,Is.EqualTo(newEmail));
        }

        [Test]
        public void ShouldLoadExistingEmail()
        {
            var email = emailRepository.Load(savedEmail.Id);

            Assert.IsNotNull(email);
            Assert.That(email.Id,Is.EqualTo(savedEmail.Id));

        }

        [Test]
        public void ShouldLoadExistingEmailByAddress()
        {
            var email = emailRepository.Load(savedEmail.Address);

            Assert.IsNotNull(email);
            Assert.That(email.Address,Is.EqualTo(savedEmail.Address));

        }

        [Test]
        public void ShouldLoadAllExistingEmails()
        {
            testDataHelper.CreateEmail(EmailMother.Official(savedConstituent));

            var emails = emailRepository.LoadAll(savedConstituent.Id);
            Assert.That(emails.Count,Is.EqualTo(2));
        }

        [Test]
        public void ShouldDeleteAnExistingEmail()
        {
            emailRepository.Delete(savedEmail.Id);

            var email = emailRepository.Load(savedEmail.Id);
            Assert.IsNull(email);
        }
    }
}