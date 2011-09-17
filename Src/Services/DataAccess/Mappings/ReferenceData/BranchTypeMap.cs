using Kallivayalil.Domain.ReferenceData;

namespace Kallivayalil.DataAccess.Mappings.ReferenceData
{
    public class BranchTypeMap : AbstractEntityMap<BranchType>
    {
        public BranchTypeMap()
        {
            Table("BranchType");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Identity().Column("Id");
            Map(x => x.Description).Not.Nullable().Column("Description");
            MapTimeStampColumns();
        }
    }
}