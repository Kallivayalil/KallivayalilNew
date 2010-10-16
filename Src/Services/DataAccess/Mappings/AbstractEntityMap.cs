using FluentNHibernate.Mapping;
using Kallivayalil.Common;

namespace Kallivayalil.DataAccess.Mappings
{
    public class AbstractEntityMap<T> : ClassMap<T> where T : Entity
    {
        public void MapTimeStampColumns()
        {
            Map(x => x.CreatedDateTime).Column("CreatedDateTime");
            Map(x => x.CreatedBy).Column("CreatedBy");
            Map(x => x.UpdatedDateTime).Column("UpdatedDateTime");
            Map(x => x.UpdatedBy).Column("UpdatedBy");
        }
        
    }
}