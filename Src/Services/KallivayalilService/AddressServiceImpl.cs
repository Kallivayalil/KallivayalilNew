using System;
using System.Collections.Generic;
using Kallivayalil.Common;
using Kallivayalil.DataAccess.Repositories;
using Kallivayalil.Domain;
using Kallivayalil.Domain.ReferenceData;
using Kallivayalil.Domain.Validators;

namespace Kallivayalil
{
    public class AddressServiceImpl : BaseServiceImpl
    {
        private readonly AddressRepository repository;
        private AddressValidator validator;

        public AddressServiceImpl()
        {
            repository = new AddressRepository();
            validator = new AddressValidator();
        }

        public Address CreateAddress(Address address)
        {
            LoadAddressType(address);
            validator.Validate(address).ProcessValidationResults();
            return repository.Save(address);
        }

        private void LoadAddressType(Address address)
        {
            if (Entity.IsNull(address.Type))
            {
                throw new BadRequestException("AddressType can not be null");
            }
            address.Type = repository.Load<AddressType>(address.Type.Id);
        }

        public Address UpdateAddress(Address address)
        {
            LoadAddressType(address);
            validator.Validate(address).ProcessValidationResults();
            return repository.Update(address);
        }

        public void DeleteAddress(string id)
        {
            repository.Delete(Convert.ToInt32(id));
        }

        public Address FindAddress(string id)
        {
            return repository.Load(Convert.ToInt32(id));
        }

        public IList<Address> FindAddresses(string constituentId)
        {
            return repository.LoadAll(Convert.ToInt32(constituentId));
        }
    }
}