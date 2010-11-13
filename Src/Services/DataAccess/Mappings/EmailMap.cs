using Kallivayalil.Domain;

namespace Kallivayalil.DataAccess.Mappings
{
    public class EmailMap : AbstractEntityMap<Email>
    {
        public EmailMap()
        {
            Table("Emails");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.HiLo("NextIds", "NextId", "0", "type='EML'");
            Map(x => x.Type).Not.Nullable().Column("Type");
            Map(x => x.Address).Not.Nullable().Column("Address");
            References(x => x.Constituent).Column("ConstituentId");
            MapTimeStampColumns();
        }
    }
}