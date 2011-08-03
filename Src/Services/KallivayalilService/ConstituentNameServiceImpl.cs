using System;
using Kallivayalil.Common;
using Kallivayalil.DataAccess.Repositories;
using Kallivayalil.Domain;
using Kallivayalil.Domain.ReferenceData;

namespace Kallivayalil
{
    public class ConstituentNameServiceImpl
    {
        private readonly ConstituentNameRepository repository;


        private void LoadSalutationType(ConstituentName name)
        {
            if (Entity.IsNull(name.Salutation))
            {
                throw new BadRequestException("SalutationType can not be null");
            }

            name.Salutation = repository.Load<SalutationType>(name.Salutation.Id);
        }

        public ConstituentNameServiceImpl(ConstituentNameRepository constituentNameRepository)
        {
            repository = constituentNameRepository;
        }

        public ConstituentName UpdateConstituentName(string id, ConstituentName name)
        {
            LoadSalutationType(name);
            if (repository.Exists<ConstituentName>(Convert.ToInt32(id)))
            {
                return repository.Update(name);
            }
            return null;
        }

    }
}