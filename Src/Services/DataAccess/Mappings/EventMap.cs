using Kallivayalil.Domain;

namespace Kallivayalil.DataAccess.Mappings
{
    public class EventMap : AbstractEntityMap<Event>
    {
        public EventMap()
        {
            Table("Events");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.HiLo("NextIds", "NextId", "0", "type='EVT'");
            Map(x => x.EventTitle).Not.Nullable().Column("EventTitle");
            Map(x => x.EventDescription).Not.Nullable().Column("EventDescription");
            Map(x => x.StartDate).Not.Nullable().Column("StartDate");
            Map(x => x.EndDate).Not.Nullable().Column("EndDate");
            Map(x => x.ContactPerson).Not.Nullable().Column("ContactPerson");
            Map(x => x.IsApproved).Not.Nullable().Column("IsApproved");
            References(x => x.Constituent).Column("ConstituentId");
            References(x => x.Type).Column("Type");
            MapTimeStampColumns();
        }
    }
}