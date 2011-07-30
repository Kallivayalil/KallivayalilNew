using Kallivayalil.Domain.ReferenceData;

namespace Kallivayalil.DataAccess.Mappings.ReferenceData
{
    public class AssociationTypeMap : AbstractEntityMap<AssociationType>
    {
        public AssociationTypeMap()
        {
            Table("AssociationType");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Identity().Column("Id");
            References(x => x.ReciprocalType).Column("ReciprocalType");
            Map(x => x.Description).Not.Nullable().Column("Description");
            MapTimeStampColumns();
        }
    }
}