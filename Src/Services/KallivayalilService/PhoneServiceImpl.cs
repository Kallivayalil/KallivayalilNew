using System;
using System.Collections.Generic;
using Kallivayalil.DataAccess.Repositories;
using Kallivayalil.Domain;

namespace Kallivayalil
{
    public class PhoneServiceImpl
    {
        private readonly PhoneRepository repository;
        private readonly ConstituentRepository constituentRepository;

        public PhoneServiceImpl()
        {
            repository = new PhoneRepository();
            constituentRepository = new ConstituentRepository();
        }

        public Phone CreatePhone(Phone phone)
        {
            return repository.Save(phone);
        }


        public Phone UpdatePhone(Phone phone)
        {
            return repository.Update(phone);
        }

        public Phone FindPhone(string phoneId)
        {
            return repository.Load(Convert.ToInt32(phoneId));
        }

        public void DeletePhone(string phoneId)
        {
            repository.Delete(Convert.ToInt32(phoneId));
        }

        public IList<Phone> FindPhones(string constituentId)
        {
            var constituent = constituentRepository.Load(Convert.ToInt32(constituentId));
            return repository.LoadAll(constituent);
        }
    }
}