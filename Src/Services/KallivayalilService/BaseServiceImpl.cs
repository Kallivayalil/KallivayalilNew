using Kallivayalil.DataAccess.Repositories;

namespace Kallivayalil
{
    public class BaseServiceImpl
    {
        public BaseServiceImpl(IRepository repository) {}

        protected void PrimaryCheckAndToggle<T>(T entity)
        {
            var isPrimaryProperty = typeof(T).GetProperty("IsPrimary");

            var isPrimary = isPrimaryProperty.GetValue(entity,null);

        }
    }
}