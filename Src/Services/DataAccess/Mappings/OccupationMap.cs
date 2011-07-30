using Kallivayalil.Domain;

namespace Kallivayalil.DataAccess.Mappings
{
    public class OccupationMap : AbstractEntityMap<Occupation>
    {
        public OccupationMap()
        {
            Table("Occupations");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.HiLo("NextIds", "NextId", "0", "type='OCC'");
            Map(x => x.OccupationName).Not.Nullable().Column("OccupationName");
            Map(x => x.Description).Not.Nullable().Column("Description");
            Map(x => x.IsPrimary).Not.Nullable().Column("IsPrimary");
            References(x => x.Constituent).Column("ConstituentId");
            References(x => x.Address).Column("AddressId");
            References(x => x.Type).Column("Type");
            MapTimeStampColumns();
        }
    }
}