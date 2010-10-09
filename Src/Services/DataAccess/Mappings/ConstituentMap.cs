using FluentNHibernate.Mapping;
using Kallivayalil.Domain;

namespace Kallivayalil.DataAccess.Mappings {
    
    
    public class ConstituentMap : ClassMap<Constituent> {
        
        public ConstituentMap() {
			Table("Constituents");
			LazyLoad();
            Id(x => x.Id).GeneratedBy.HiLo("NextIds","NextId","0","type='CON'");
			Map(x => x.Gender).Not.Nullable().Column("Gender");
			Map(x => x.BranchName).Not.Nullable().Column("BranchName");
			Map(x => x.HouseName).Column("HouseName");
			Map(x => x.BornOn).Column("BornOn");
			Map(x => x.DiedOn).Column("DiedOn");
			Map(x => x.HasExpired).Column("HasExpired");
			Map(x => x.MaritialStatus).Not.Nullable().Column("MaritialStatus");
			Map(x => x.IsRegistered).Not.Nullable().Column("IsRegistered");
			Map(x => x.CreatedDateTime).Column("CreatedDateTime");
			Map(x => x.CreatedBy).Column("CreatedBy");
			Map(x => x.UpdatedDateTime).Column("UpdatedDateTime");
			Map(x => x.UpdatedBy).Column("UpdatedBy");
        }
    }
}
