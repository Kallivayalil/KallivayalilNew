using System.Collections.Generic;
using Kallivayalil.Domain;

namespace Kallivayalil
{
    public interface IPhoneServiceImpl
    {
        Phone CreatePhone(Phone phone);
        Phone UpdatePhone(Phone phone);
        Phone FindPhone(string phoneId);
        void DeletePhone(string phoneId);
        IList<Phone> FindPhones(string constituentId);
        void SetConstituentAndUpdatePhone(string id, Constituent existingConstituent);
    }
}