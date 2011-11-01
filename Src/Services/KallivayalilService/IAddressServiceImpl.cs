using System.Collections.Generic;
using Kallivayalil.Domain;

namespace Kallivayalil
{
    public interface IAddressServiceImpl
    {
        Address CreateAddress(Address address);
        Address UpdateAddress(Address address);
        void DeleteAddress(string id);
        Address FindAddress(string id);
        IList<Address> FindAddresses(string constituentId);
        void SetConstituentAndUpdateAddress(string id, Constituent existingConstituent);
    }
}