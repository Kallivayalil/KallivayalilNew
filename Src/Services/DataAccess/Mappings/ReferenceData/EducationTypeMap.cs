using Kallivayalil.Domain.ReferenceData;

namespace Kallivayalil.DataAccess.Mappings.ReferenceData
{
    public class EducationTypeMap : AbstractEntityMap<EducationType>
    {
        public EducationTypeMap()
        {
            Table("EducationType");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Identity().Column("Id");
            Map(x => x.Description).Not.Nullable().Column("Description");
            MapTimeStampColumns();
        }
    }
}