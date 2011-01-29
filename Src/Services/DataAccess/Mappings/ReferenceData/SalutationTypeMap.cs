using Kallivayalil.Domain.ReferenceData;

namespace Kallivayalil.DataAccess.Mappings.ReferenceData
{
    public class SalutationTypeMap : AbstractEntityMap<SalutationType>
    {
        public SalutationTypeMap()
        {
            Table("SalutationType");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Identity().Column("Id");
            Map(x => x.Description).Not.Nullable().Column("Description");
            MapTimeStampColumns();
        }
    }
}