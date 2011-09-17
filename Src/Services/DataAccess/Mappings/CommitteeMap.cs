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
            Map(x => x.StartDate).Not.Nullable().Column("StartDate");
            Map(x => x.EndDate).Not.Nullable().Column("EndDate");
            References(x => x.Constituent).Column("ConstituentId");
            References(x => x.Type).Column("Position");
            MapTimeStampColumns();
        }
    }
}