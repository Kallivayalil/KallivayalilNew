using Kallivayalil.Domain;

namespace Kallivayalil.DataAccess.Mappings
{
    public class EducationDetailsMap : AbstractEntityMap<EducationDetail>
    {
        public EducationDetailsMap()
        {
            Table("EducationDetails");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.HiLo("NextIds", "NextId", "0", "type='EDU'");
            Map(x => x.Qualification).Not.Nullable().Column("Qualification");
            Map(x => x.InstituteName).Not.Nullable().Column("InstituteName");
            Map(x => x.InstituteLocation).Not.Nullable().Column("InstituteLocation");
            Map(x => x.YearOfGraduation).Not.Nullable().Column("YearOfGraduation");
            References(x => x.Constituent).Column("ConstituentId");
            References(x => x.Type).Column("Type");
            MapTimeStampColumns();
        }
    }
}