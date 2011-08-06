using System;
using Kallivayalil.Client;
using Kallivayalil.Domain;

namespace Tests.Integration.Mothers
{
    public static class EventDataMother
    {
        public static EventData Birthday(Constituent constituent)
        {
            return new EventData
            {
                Type = new EventTypeData(){Description = "Birthday",Id = 1},
                EventTitle = "Birthday Party",
                EventDescription = "Party at 10",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(2),
                Constituent = new LinkData(){Id = constituent.Id},
                ContactPerson = "Jessica",
                ContactNumber = "998006543",
                CreatedBy = "James Franklin",
                IsApproved = true
            };
        }

        public static EventData Anniversary()
        {
            return new EventData
            {
                Type = new EventTypeData() { Description = "Anniversary", Id = 2 },
                EventTitle = "Anniversary Party",
                EventDescription = "Anniversary at 10",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(2),
                ContactPerson = "Jessica",
                ContactNumber = "998006543",
                CreatedBy = "James Franklin",
                IsApproved = false
            };
        }


        public static EventData Anniversary(Event @event)
        {
            return new EventData
            {
                Type = new EventTypeData { Description = "Anniversary", Id = 1 },
                EventTitle = @event.EventTitle,
                EventDescription = @event.EventDescription,
                StartDate = @event.StartDate,
                EndDate = @event.EndDate,
                ContactPerson = @event.ContactPerson,
                ContactNumber = @event.ContactNumber,
                CreatedBy = @event.CreatedBy,
                IsApproved = @event.IsApproved

            };
        }
    }
}