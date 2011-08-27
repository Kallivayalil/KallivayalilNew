using System;
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
    public class EventTest
    {
        private string baseUri = "http://localhost/kallivayalilService/KallivayalilService.svc/Events";
        private Constituent savedConstituent;
        private TestDataHelper testDataHelper;

        [SetUp]
        public void SetUp()
        {
            testDataHelper = new TestDataHelper();

            savedConstituent = testDataHelper.CreateConstituent(ConstituentMother.ConstituentWithName(ConstituentNameMother.JamesFranklin()));
            testDataHelper.CreatePhone(PhoneMother.PrimaryMobile(savedConstituent));
        }

        [TearDown]
        public void TearDown()
        {
            testDataHelper.HardDeleteEvents();
            testDataHelper.HardDeletePhones();
            testDataHelper.HardDeleteConstituents();
            testDataHelper.HardDeleteConstituentNames();
        }

        [Test]
        public void ShouldSaveEvent()
        {
            var savedEvent = HttpHelper.Post(string.Format("{0}", baseUri), EventDataMother.Birthday(savedConstituent));

            Assert.IsNotNull(savedEvent);
            Assert.That(savedEvent.Id, Is.GreaterThan(0));
        }

        [Test]
        public void ShouldUpdateExistingEvent()
        {
            var @event = testDataHelper.CreateEvent(EventMother.Anniversary());

            var eventData = EventDataMother.Anniversary(@event);
            
            eventData.Constituent = new LinkData(){Id = savedConstituent.Id};
            eventData.IsApproved = true;
            var updatedData = HttpHelper.Put(string.Format("{0}/{1}", baseUri, @event.Id), eventData);

            Assert.That(updatedData.Constituent.Id, Is.EqualTo(savedConstituent.Id));
            Assert.IsTrue(updatedData.IsApproved);
        }


        [Test]
        public void ShouldLoadExitingEvent()
        {
            var @event = testDataHelper.CreateEvent(EventMother.Anniversary());

            var eventData = HttpHelper.Get<EventData>(string.Format("{0}/{1}", baseUri, @event.Id));

            Assert.That(eventData.Id, Is.GreaterThan(0));
        }

        [Test]
        public void ShouldLoadAllEventsForToday()
        {
            testDataHelper.CreateEvent(EventMother.Birthday(savedConstituent));
            testDataHelper.CreateEvent(EventMother.Birthday(savedConstituent));
            testDataHelper.CreateEvent(EventMother.Birthday(savedConstituent));
            testDataHelper.CreateEvent(EventMother.Anniversary());
            testDataHelper.CreateEvent(EventMother.Anniversary());

            var eventsData = HttpHelper.Get<EventsData>(string.Format("{0}?isApproved={1}&startDate={2}&endDate={3}&includeBirthdaysAndAnniversarys={4}", baseUri, "true", DateTime.Today, DateTime.Today, "false"));

            Assert.That(eventsData.Count, Is.EqualTo(3));
        }
        
        [Test]
        public void ShouldLoadAllEventsForTodayIncludingBirthdays()
        {
            testDataHelper.CreateEvent(EventMother.Birthday(savedConstituent));
            testDataHelper.CreateEvent(EventMother.Birthday(savedConstituent));
            testDataHelper.CreateEvent(EventMother.Birthday(savedConstituent));
            testDataHelper.CreateEvent(EventMother.Anniversary());
            testDataHelper.CreateEvent(EventMother.Anniversary());

            var eventsData = HttpHelper.Get<EventsData>(string.Format("{0}?isApproved={1}&startDate={2}&endDate={3}&includeBirthdaysAndAnniversarys={4}", baseUri, "true", DateTime.Today, DateTime.Today, "true"));

            Assert.That(eventsData.Count, Is.EqualTo(4));
        } 
        
        [Test]
        public void ShouldLoadAllEventsForGivenDateRange()
        {
            testDataHelper.CreateEvent(EventMother.Event1(savedConstituent));
            testDataHelper.CreateEvent(EventMother.Event2(savedConstituent));
            testDataHelper.CreateEvent(EventMother.Event1(savedConstituent));
            testDataHelper.CreateEvent(EventMother.Anniversary());
            testDataHelper.CreateEvent(EventMother.Anniversary());

            var eventsData = HttpHelper.Get<EventsData>(string.Format("{0}?isApproved={1}&startDate={2}&endDate={3}&includeBirthdaysAndAnniversarys={4}", baseUri, "true", DateTime.Today.AddDays(-5), DateTime.Today.AddDays(5), "true"));

            Assert.That(eventsData.Count, Is.EqualTo(3));
        }

        [Test]
        public void ShouldDeleteExistingEvent()
        {
            var @event = testDataHelper.CreateEvent(EventMother.Anniversary());

            HttpHelper.DoHttpDelete(string.Format("{0}/{1}", baseUri, @event.Id));

            var eventData = HttpHelper.DoHttpGet(string.Format("{0}/{1}", baseUri, @event.Id));
            Assert.That(eventData.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }
    }
}