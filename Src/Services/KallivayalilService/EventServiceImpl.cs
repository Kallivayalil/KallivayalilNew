using System;
using System.Collections.Generic;
using Kallivayalil.Common;
using Kallivayalil.DataAccess.Repositories;
using Kallivayalil.Domain;
using Kallivayalil.Domain.ReferenceData;
using FluentValidation.Internal;
using System.Linq;

namespace Kallivayalil
{
    public class EventServiceImpl 
    {
        private readonly EventRepository repository;
        private readonly ConstituentRepository constituentRepository;
        private readonly ReferenceDataRepository referenceDataRepository;

        private void LoadEventType(Event @event)
        {
            if (Entity.IsNull(@event.Type))
            {
                throw new BadRequestException("EventType can not be null");
            }

            @event.Type = repository.Load<EventType>(@event.Type.Id);
        }


        public EventServiceImpl(EventRepository eventRepository, ConstituentRepository constituentRepository, ReferenceDataRepository referenceDataRepository)
        {
            repository = eventRepository;
            this.referenceDataRepository = referenceDataRepository;
            this.constituentRepository = constituentRepository;
        }

        public Event CreateEvent(Event @event)
        {
            LoadEventType(@event);
            return repository.Save(@event);
        }

        public Event UpdateEvent(Event @event)
        {
            LoadEventType(@event);
            return repository.Update(@event);
        }

        public Event FindEvent(string eventId)
        {
            return repository.Load(Convert.ToInt32(eventId));
        }

        public void DeletEvent(string eventId)
        {
            repository.Delete(Convert.ToInt32(eventId));
        }


        public IEnumerable<Event> FindEvents(bool isApproved, DateTime startDate, DateTime endDate, bool includeBirthdays)
        {
            if(startDate.Equals(endDate))
            {
                var events = repository.LoadAll(isApproved);
                if(includeBirthdays)
                {
                    var constituents = constituentRepository.LoadAllConstituentsWithBirthdayToday();
                    var birthdays = CreateEvents(constituents);
                    events = events.Union(birthdays).ToList();
                }
                return events;
            }
            return repository.LoadAll(isApproved, startDate, endDate);
        }

        private IEnumerable<Event> CreateEvents(IEnumerable<Constituent> constituents)
        {
            var eventTypes = referenceDataRepository.LoadAll<EventType>();
            var events = new List<Event>();
            constituents.ForEach(constituent => events.Add(new Event()
                                                               {
                                                                   Constituent = constituent,
                                                                   EventTitle =
                                                                       string.Format("{0}'s {1}",
                                                                                     constituent.Name.ToString(),
                                                                                     "Birthday"),
                                                                   StartDate = DateTime.Today,
                                                                   EndDate = DateTime.Today,
                                                                   IsApproved = true,
                                                                   ContactPerson = constituent.Name.ToString(),
                                                                   Type = eventTypes.First(type => type.Description.Equals("Birthday"))
                                                               }));
            return events;
        }
    }
}