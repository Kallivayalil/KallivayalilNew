using Kallivayalil.Domain;

namespace Kallivayalil.DataAccess.Mappings
{
    public class LoginMap : AbstractEntityMap<Login>
    {
        public LoginMap()
        {
            Table("Logins");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.HiLo("NextIds", "NextId", "0", "type='LGN'");
            Map(x => x.IsAdmin).Column("IsAdmin").Not.Nullable();
            Map(x => x.Password).Not.Nullable().Column("Password");
            References(x => x.Email).Column("Email").Cascade.None();
            MapTimeStampColumns();
        }
    }
}