using Kallivayalil.Domain.ReferenceData;

namespace Kallivayalil.DataAccess.Mappings.ReferenceData
{
    public class EventTypeMap : AbstractEntityMap<EventType>
    {
        public EventTypeMap()
        {
            Table("EventType");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Identity().Column("Id");
            Map(x => x.Description).Not.Nullable().Column("Description");
            MapTimeStampColumns();
        }
    }
}