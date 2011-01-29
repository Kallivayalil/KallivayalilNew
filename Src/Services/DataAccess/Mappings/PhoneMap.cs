using Kallivayalil.Domain;

namespace Kallivayalil.DataAccess.Mappings {
    
    
    public class PhoneMap : AbstractEntityMap<Phone> {
        
        public PhoneMap() {
			Table("Phones");
			LazyLoad();
            Id(x => x.Id).GeneratedBy.HiLo("NextIds", "NextId", "0", "type='PHN'");
			Map(x => x.Number).Not.Nullable().Column("Number");
			References(x => x.Constituent).Column("ConstituentId");
            References(x => x.Address).Column("AddressId");
            References(x => x.Type).Column("Type");
            MapTimeStampColumns();
        }
    }
}
