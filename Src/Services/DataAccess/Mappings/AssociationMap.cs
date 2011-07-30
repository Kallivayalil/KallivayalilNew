using Kallivayalil.Domain;

namespace Kallivayalil.DataAccess.Mappings
{
    public class AssociationMap : AbstractEntityMap<Association>
    {
        public AssociationMap()
        {
            Table("Associations");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.HiLo("NextIds", "NextId", "0", "type='ASN'");
            References(x => x.Type).Column("Type");
            References(x => x.Constituent).Column("ConstituentId");
            References(x => x.AssociatedConstituent).Column("AssociatedConstituentId");
            References(x => x.ReciprocalAssociation).Column("ReciprocalId");
            Map(x => x.AssociatedConstituentName).Column("AssociatedConstituentName");
            Map(x => x.StartDate).Column("StartDate");
            Map(x => x.EndDate).Column("EndDate");
            MapTimeStampColumns();
        }
    }
}