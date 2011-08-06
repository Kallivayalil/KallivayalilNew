using System;
using System.Collections.Generic;
using Kallivayalil.Common;
using Kallivayalil.DataAccess.Repositories;
using Kallivayalil.Domain;
using Kallivayalil.Domain.ReferenceData;

namespace Kallivayalil
{
    public class EventServiceImpl 
    {
        private readonly EventRepository repository;

        private void LoadEventType(Event @event)
        {
            if (Entity.IsNull(@event.Type))
            {
                throw new BadRequestException("EventType can not be null");
            }

            @event.Type = repository.Load<EventType>(@event.Type.Id);
        }


        public EventServiceImpl(EventRepository eventRepository) 
        {
            repository = eventRepository;
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


        public IList<Event> FindEvents(bool isApproved)
        {
            return repository.LoadAll(isApproved);
        }
    }
}