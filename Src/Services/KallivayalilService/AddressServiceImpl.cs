using System;
using System.Collections.Generic;
using System.Linq;
using Kallivayalil.Common;
using Kallivayalil.DataAccess.Repositories;
using Kallivayalil.Domain;
using Kallivayalil.Domain.ReferenceData;
using Kallivayalil.Domain.Validators;

namespace Kallivayalil
{
    public class AddressServiceImpl : BaseServiceImpl<Address>, IAddressServiceImpl
    {
        private readonly AddressRepository repository;
        private readonly AddressValidator validator;

        public AddressServiceImpl(AddressRepository repository) : base(repository)
        {
            this.repository = repository;
            validator = new AddressValidator();
        }

        public Address CreateAddress(Address address)
        {
            LoadAddressType(address);
            validator.Validate(address).ProcessValidationResults();
            OneEntityShouldBePrimary(address);
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
            OneEntityShouldBePrimary(address);
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

        public void SetConstituentAndUpdateAddress(string id, Constituent existingConstituent)
        {
            var address = FindAddresses(id).First();
            address.Constituent = existingConstituent;
            UpdateAddress(address);
        }
    }
}