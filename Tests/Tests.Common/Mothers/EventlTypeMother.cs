using Kallivayalil.Domain.ReferenceData;

namespace Tests.Common.Mothers
{
    public static class EventlTypeMother
    {
        public static EventType Birthday()
        {
            return new EventType() {Id = 1, Description = "Birthday"};
        }

        public static EventType Anniversary()
        {
            return new EventType() { Id = 1, Description = "Anniversary" };
        }

       
    }
}