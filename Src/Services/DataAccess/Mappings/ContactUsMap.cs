using Kallivayalil.Domain;

namespace Kallivayalil.DataAccess.Mappings
{
    public class ContactUsMap : AbstractEntityMap<ContactUs>
    {
        public ContactUsMap()
        {
            Table("ContactUs");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.HiLo("NextIds", "NextId", "0", "type='CNS'");
            Map(x => x.Name).Not.Nullable().Column("Name");
            Map(x => x.Email).Not.Nullable().Column("Email");
            Map(x => x.Comments).Not.Nullable().Column("Comments");
            MapTimeStampColumns();
        }
    }
}