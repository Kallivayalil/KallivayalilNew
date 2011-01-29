using System;
using System.Collections.Generic;
using Kallivayalil.Common;
using Kallivayalil.DataAccess.Repositories;
using Kallivayalil.Domain;
using Kallivayalil.Domain.ReferenceData;

namespace Kallivayalil
{
    public class PhoneServiceImpl
    {
        private readonly PhoneRepository repository;
        private readonly ConstituentRepository constituentRepository;

        private void LoadPhoneType(Phone phone)
        {
            if (Entity.IsNull(phone.Type))
            {
                throw new BadRequestException("PhoneType can not be null");
            }

            phone.Type = repository.Load<PhoneType>(phone.Type.Id);
        }


        public PhoneServiceImpl()
        {
            repository = new PhoneRepository();
            constituentRepository = new ConstituentRepository();
        }

        public Phone CreatePhone(Phone phone)
        {
            LoadPhoneType(phone);
            return repository.Save(phone);
        }


        public Phone UpdatePhone(Phone phone)
        {
            LoadPhoneType(phone);
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