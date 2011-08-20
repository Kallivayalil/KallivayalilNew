using System;
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
            testDataHelper.session.Clear();
            testDataHelper.HardDeleteEvents();
            testDataHelper.HardDeleteConstituents();
            testDataHelper.HardDeleteConstituentNames();
        }

        [Test]
        public void ShouldSaveEvent()
        {
            var savedEvent = eventRepository.Save(EventMother.Birthday(savedConstituent));

            Assert.That(savedEvent.Id, Is.GreaterThan(0));
        }  
        
        [Test]
        public void ShouldUpdateEvent()
        {
            savedEvent.Constituent = savedConstituent;
            savedEvent.IsApproved = true;
            var updateEvent = eventRepository.Update(savedEvent);

            Assert.IsNotNull(updateEvent.Constituent);
            Assert.That(updateEvent.Constituent.Id,Is.EqualTo(savedConstituent.Id));
            Assert.IsTrue(updateEvent.IsApproved);
        }

        [Test]
        public void ShouldDeleteEvent()
        {
            eventRepository.Delete(savedEvent.Id);

            var @event = eventRepository.Get<Event>(savedEvent.Id);
            Assert.IsNull(@event);
        }


        [Test]
        public void ShouldLoadEvent()
        {
            var @event = eventRepository.Load(savedEvent.Id);

            Assert.That(@event.Id, Is.EqualTo(savedEvent.Id));
        }  
        
        [Test]
        public void ShouldLoadAllEventsForToday()
        {
            testDataHelper.CreateEvent(EventMother.Birthday(savedConstituent));

            var @event = eventRepository.LoadAll(true);

            Assert.That(@event.Count, Is.EqualTo(1));
        }    
        
        [Test]
        public void ShouldLoadAllEventsForGivenDateRange()
        {
            testDataHelper.CreateEvent(EventMother.Birthday(savedConstituent));
            testDataHelper.CreateEvent(EventMother.Event1(savedConstituent));
            testDataHelper.CreateEvent(EventMother.Event2(savedConstituent));
            
            var @event = eventRepository.LoadAll(true,DateTime.Today.AddDays(-5),DateTime.Today.AddDays(5));

            Assert.That(@event.Count, Is.EqualTo(3));
        }  


        
    }
}