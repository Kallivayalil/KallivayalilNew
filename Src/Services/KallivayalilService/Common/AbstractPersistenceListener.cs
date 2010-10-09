
namespace Kallivayalil.Common
{
    public class AbstractPersistenceListener
    {
        protected bool HasValidAttribute<T>(Entity entity)
        {
            return entity == null || !entity.HasAttribute(typeof(T));
        }
    }
}