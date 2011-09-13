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
            Map(x => x.BranchName).Not.Nullable().Column("BranchName");
            Map(x => x.HouseName).Column("HouseName");
            Map(x => x.BornOn).Column("BornOn");
            Map(x => x.DiedOn).Column("DiedOn");
            Map(x => x.HasExpired).Column("HasExpired");
            Map(x => x.MaritialStatus).Not.Nullable().Column("MaritialStatus");
            Map(x => x.IsRegistered).Not.Nullable().Column("IsRegistered");
            References(x => x.Name).Column("NameId").Cascade.All();

            HasMany(x => x.Addresses).Table("Addresses").KeyColumn("ConstituentId").Inverse().Cascade.None();
            HasMany(x => x.Emails).Table("Emails").KeyColumn("ConstituentId").Inverse().Cascade.None();
            HasMany(x => x.Phones).Table("Phones").KeyColumn("ConstituentId").Inverse().Cascade.None();
            HasMany(x => x.Occupations).Table("Occupations").KeyColumn("ConstituentId").Inverse().Cascade.None();
            HasMany(x => x.EducationDetails).Table("EducationDetails").KeyColumn("ConstituentId").Inverse().Cascade.None();
            MapTimeStampColumns();
        }
    }
}