using System;
using Kallivayalil.Domain;

namespace Tests.Common.Mothers
{
    public static class EventMother
    {
        public static Event Birthday(Constituent constituent)
        {
            return new Event
                       {
                           Type = EventlTypeMother.Birthday(),
                           EventTitle = "Birthday Party",
                           EventDescription = "Party at 10",
                           StartDate = DateTime.Now,
                           EndDate = DateTime.Now.AddDays(2),
                           Constituent = constituent,
                           ContactPerson = "Jessica",
                           ContactNumber = "998006543",
                           CreatedBy = "James Franklin",
                           IsApproved = true
                       };
        }

        public static Event Anniversary()
        {
            return new Event
                       {
                           Type = EventlTypeMother.Anniversary(),
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
      
    }
}