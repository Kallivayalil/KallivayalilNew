using System;
using Kallivayalil.DataAccess.Repositories;
using Kallivayalil.Domain;

namespace Kallivayalil
{
    public class ConstituentNameServiceImpl
    {
        private ConstituentNameRepository repository;

        public ConstituentNameServiceImpl()
        {
            repository = new ConstituentNameRepository();
        }

        public ConstituentName UpdateConstituentName(string id, ConstituentName name)
        {
            if(repository.Exists<ConstituentName>(Convert.ToInt32(id)))
                return repository.Update(name);
            return null;
        }
    }
}