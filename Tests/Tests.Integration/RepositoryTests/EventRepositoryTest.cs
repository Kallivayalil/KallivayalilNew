using Kallivayalil.DataAccess.Repositories;
using Kallivayalil.Domain;
using NUnit.Framework;
using Tests.Common.Helpers;
using Tests.Common.Mothers;

namespace Tests.Integration.RepositoryTests
{
    [TestFixture]
    public class EventRepositoryTest
    {
        private TestDataHelper testDataHelper;
        private Constituent savedConstituent;
        private Event savedEvent;
        private EventRepository eventRepository;
        private Constituent jamesFranklin;

        [SetUp]
        public void SetUp()
        {
            testDataHelper = new TestDataHelper();

            jamesFranklin = ConstituentMother.ConstituentWithName(ConstituentNameMother.JamesFranklin());
            savedConstituent = testDataHelper.CreateConstituent(jamesFranklin);

            savedEvent = testDataHelper.CreateEvent(EventMother.Anniversary());
            eventRepository = new EventRepository();

        }

        [TearDown]
        public void TearDown()
        {
            testDataHelper.HardDeleteConstituents();
            testDataHelper.HardDeleteConstituentNames();
            testDataHelper.HardDeleteEvents();
        }

        [Test]
        public void ShouldSaveEvent()
        {
            var savedEvent = eventRepository.Save(EventMother.Birthday(savedConstituent));

            Assert.That(savedEvent.Id, Is.GreaterThan(0));
        }  
        
        [Test]
        public void ShouldUpdateConstituentName()
        {
            savedEvent.Constituent = savedConstituent;
            savedEvent.IsApproved = true;
            var updateEvent = eventRepository.Update(savedEvent);

            Assert.IsNotNull(updateEvent.Constituent);
            Assert.That(updateEvent.Constituent.Id,Is.EqualTo(savedConstituent.Id));
            Assert.IsTrue(updateEvent.IsApproved);
        }

        [Test]
        public void ShouldDeleteConstituentName()
        {
            eventRepository.Delete(savedEvent.Id);

            var @event = eventRepository.Get<Event>(savedEvent.Id);
            Assert.IsNull(@event);
        }


        [Test]
        public void ShouldLoadConstituentName()
        {
            var @event = eventRepository.Load(savedEvent.Id);

            Assert.That(@event.Id, Is.EqualTo(savedEvent.Id));
        }
    }
}