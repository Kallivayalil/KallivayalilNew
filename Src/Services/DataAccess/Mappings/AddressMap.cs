using FluentNHibernate.Mapping;
using Kallivayalil.Domain;

namespace Kallivayalil.DataAccess.Mappings
{
    public class AddressMap : AbstractEntityMap<Address>
    {
        public AddressMap()
        {
            Table("Addresses");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.HiLo("NextIds","NextId","0","type='ADD'");
            Map(x => x.Line1).Not.Nullable().Column("Line1");
            Map(x => x.Line2).Column("Line2");
            Map(x => x.City).Not.Nullable().Column("City");
            Map(x => x.State).Not.Nullable().Column("State");
            Map(x => x.PostCode).Not.Nullable().Column("Postcode");
            Map(x => x.Country).Not.Nullable().Column("Country");
            References(x => x.Constituent).Column("ConstituentId");
            References(x => x.Type).Column("Type");
            MapTimeStampColumns();
        }
    }
}