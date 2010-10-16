using FluentNHibernate.Mapping;
using Kallivayalil.Domain;

namespace Kallivayalil.DataAccess.Mappings
{
    public class ConstituentNameMap : AbstractEntityMap<ConstituentName>
    {
        public ConstituentNameMap()
        {
            Table("ConstituentNames");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.HiLo("NextIds", "NextId", "0", "type='NAM'");
            Map(x => x.FirstName).Not.Nullable().Column("FirstName");
            Map(x => x.MiddleName).Column("MiddleName");
            Map(x => x.LastName).Not.Nullable().Column("LastName");
            Map(x => x.PreferedName).Column("PreferedName");
            Map(x => x.Salutation).Not.Nullable().Column("Salutation");
            MapTimeStampColumns();
            References(x => x.Constituent).Not.Nullable().Column("ConstituentId").Cascade.All();
        }
    }
}