using System.Collections.Generic;

namespace Kallivayalil.DataAccess.Repositories
{
    public interface ISubEntityRepository<T>
    {
        T Save(T entity);
        T Update(T entity);
        void Delete(int id);
        T Load(int id);
        IList<T> LoadAll(int constituentId);
        T GetPrimary(int constituentId);
    }
}