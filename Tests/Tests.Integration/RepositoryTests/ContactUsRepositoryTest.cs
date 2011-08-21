using Kallivayalil.DataAccess.Repositories;
using Kallivayalil.Domain;
using NUnit.Framework;
using Tests.Common.Helpers;
using Tests.Common.Mothers;

namespace Tests.Integration.RepositoryTests
{
    [TestFixture]
    public class ContactUsRepositoryTest
    {
        private TestDataHelper testDataHelper;
        private Constituent savedConstituent;
        private ContactUsRepository contactUsRepository;
        private ContactUs savedContactUs;

        [SetUp]
        public void SetUp()
        {
            testDataHelper = new TestDataHelper();
            contactUsRepository = new ContactUsRepository();
            savedContactUs = testDataHelper.CreateContactUs(new ContactUs {Name = "test",Email = "test",Comments = "test"});
        }

        [TearDown]
        public void TearDown()
        {
            testDataHelper.HardDeleteContactUs();
        }

        [Test]
        public void ShouldSaveFeedback()
        {
            var savedFeedback = contactUsRepository.Save(ContactUsMother.Test());
            Assert.That(savedFeedback.Id, Is.GreaterThan(0));
        }

        [Test]
        public void ShouldLoadExistingFeedback()
        {
            var feedback = contactUsRepository.Load(savedContactUs.Id);

            Assert.IsNotNull(feedback);
            Assert.That(feedback.Id, Is.EqualTo(savedContactUs.Id));
        }
  
        [Test]
        public void ShouldLoadAllFeedback()
        {
            testDataHelper.CreateContactUs(new ContactUs { Name = "test", Email = "test", Comments = "test" });
            testDataHelper.CreateContactUs(new ContactUs { Name = "test", Email = "test", Comments = "test" });
            testDataHelper.CreateContactUs(new ContactUs { Name = "test", Email = "test", Comments = "test" });

            var feedbacks = contactUsRepository.LoadAll();

            Assert.IsNotNull(feedbacks);
            Assert.That(feedbacks.Count, Is.EqualTo(4));
        }

        [Test]
        public void ShouldDeleteExistingFeedback()
        {
            contactUsRepository.Delete(savedContactUs.Id);

            var feedback = contactUsRepository.Load(savedContactUs.Id);
            Assert.IsNull(feedback);
        }


    }
}