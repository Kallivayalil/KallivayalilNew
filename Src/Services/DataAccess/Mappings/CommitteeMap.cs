using Kallivayalil.Domain;

namespace Kallivayalil.DataAccess.Mappings
{
    public class CommitteeMap : AbstractEntityMap<Committee>
    {
        public CommitteeMap()
        {
            Table("Committees");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.HiLo("NextIds", "NextId", "0", "type='COM'");
            Map(x => x.StartYear).Not.Nullable().Column("StartYear");
            Map(x => x.EndYear).Not.Nullable().Column("EndYear");
            References(x => x.Constituent).Column("ConstituentId");
            References(x => x.Type).Column("Position");
            MapTimeStampColumns();
        }
    }
}