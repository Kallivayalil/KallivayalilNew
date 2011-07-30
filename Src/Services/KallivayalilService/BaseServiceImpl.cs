using Kallivayalil.Common;
using Kallivayalil.DataAccess.Repositories;
using Kallivayalil.Domain;

namespace Kallivayalil
{
    public class BaseServiceImpl<T> where T : PrimaryEntity
    {
        private readonly ISubEntityRepository<T> repository;

        public BaseServiceImpl(ISubEntityRepository<T> repository)
        {
            this.repository = repository;
        }

        protected void FirstEntityShouldBePrimary(T entity)
        {
            var isPrimaryProperty = typeof (T).GetProperty("IsPrimary");
            var isPrimary = (bool) isPrimaryProperty.GetValue(entity, null);

            var constituentProperty = typeof (T).GetProperty("Constituent");
            var constituent = (Constituent) constituentProperty.GetValue(entity, null);

            if (!isPrimary && !Entity.IsNull(constituent))
            {
                var existingPrimary = repository.GetPrimary(constituent.Id);
                if (Entity.IsNull(existingPrimary))
                {
                    isPrimaryProperty.SetValue(entity, true, null);
                }
                else
                {
                    if (entity.Id == existingPrimary.Id)
                    {
                        throw new BadRequestException(string.Format("Can not update a Primary to Non-Primary {0}", typeof (T).Name));
                    }
                }
            }
        }

        protected void TogglePrimaryOnExistingEntity(T entity)
        {
            var isPrimaryProperty = typeof (T).GetProperty("IsPrimary");
            var isPrimary = (bool) isPrimaryProperty.GetValue(entity, null);

            var constituentProperty = typeof (T).GetProperty("Constituent");
            var constituent = (Constituent) constituentProperty.GetValue(entity, null);

            if (isPrimary && !Entity.IsNull(constituent))
            {
                var existingPrimary = repository.GetPrimary(constituent.Id);
                if (!Entity.IsNull(existingPrimary))
                {
                    isPrimaryProperty.SetValue(existingPrimary, false, null);
                    repository.Save(existingPrimary);
                }
            }
        }

        protected void OneEntityShouldBePrimary(T entity)
        {
            TogglePrimaryOnExistingEntity(entity);
            FirstEntityShouldBePrimary(entity);
        }
    }
}