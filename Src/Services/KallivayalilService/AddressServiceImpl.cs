using System;
using System.Collections.Generic;
using Kallivayalil.DataAccess.Repositories;
using Kallivayalil.Domain;

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
            return repository.Save(address);
        }

        public Address UpdateAddress(Address address)
        {
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