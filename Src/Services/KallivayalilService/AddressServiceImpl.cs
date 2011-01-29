using System;
using System.Collections.Generic;
using Kallivayalil.Common;
using Kallivayalil.DataAccess.Repositories;
using Kallivayalil.Domain;
using Kallivayalil.Domain.ReferenceData;

namespace Kallivayalil
{
    public class AddressServiceImpl
    {
        private readonly AddressRepository repository;

        public AddressServiceImpl()
        {
            repository = new AddressRepository();
        }

        public Address CreateAddress(Address address)
        {
            LoadAddressType(address);
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