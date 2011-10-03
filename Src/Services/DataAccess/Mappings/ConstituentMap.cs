using Kallivayalil.Domain;

namespace Kallivayalil.DataAccess.Mappings
{
    public class ConstituentMap : AbstractEntityMap<Constituent>
    {
        public ConstituentMap()
        {
            Table("Constituents");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.HiLo("NextIds", "NextId", "0", "type='CON'");
            Map(x => x.Gender).Not.Nullable().Column("Gender");
            Map(x => x.HouseName).Column("HouseName");
            Map(x => x.BornOn).Column("BornOn");
            Map(x => x.BornInto).Column("BornInto");
            Map(x => x.DiedOn).Column("DiedOn");
            Map(x => x.HasExpired).Column("HasExpired");
            Map(x => x.ProfilePicture).Column("profilepicture");
            Map(x => x.MaritialStatus).Not.Nullable().Column("MaritialStatus");
            Map(x => x.IsRegistered).Not.Nullable().Column("IsRegistered");
             
            References(x => x.Name).Column("NameId").Cascade.All();
            References(x => x.BranchName).Column("BranchName");
            MapTimeStampColumns();
        }
    }
}