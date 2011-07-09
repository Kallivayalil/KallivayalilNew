using System.Collections.Generic;
using Kallivayalil.DataAccess.Repositories;
using Kallivayalil.Domain.ReferenceData;

namespace Kallivayalil
{
    public class ReferenceDataServiceImpl
    {
        private readonly ReferenceDataRepository repository;

        public ReferenceDataServiceImpl()
        {
            repository = new ReferenceDataRepository();
        }

        public IList<PhoneType> GetPhoneTypes()
        {
            return repository.LoadAll<PhoneType>();
        }

        public IList<EmailType> GetEmailTypes()
        {
            return repository.LoadAll<EmailType>();
        }

        public IList<AddressType> GetAddressTypes()
        {
            return repository.LoadAll<AddressType>();
        }
    }
}