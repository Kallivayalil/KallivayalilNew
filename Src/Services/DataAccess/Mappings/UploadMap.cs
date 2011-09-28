using Kallivayalil.Domain;

namespace Kallivayalil.DataAccess.Mappings
{
    public class UploadMap : AbstractEntityMap<Upload>
    {
        public UploadMap()
        {
            Table("UploadFiles");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.HiLo("NextIds", "NextId", "0", "type='UPF'");
            Map(x => x.Name).Not.Nullable().Column("FileName");
            Map(x => x.Description).Not.Nullable().Column("FileDescription");
            References(x => x.Constituent).Column("ConstituentId");
            MapTimeStampColumns();
        }
    }
}