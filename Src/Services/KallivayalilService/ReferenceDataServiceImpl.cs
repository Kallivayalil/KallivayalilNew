using System;
using System.Collections.Generic;
using Kallivayalil.DataAccess.Repositories;
using Kallivayalil.Domain.ReferenceData;

namespace Kallivayalil
{
    public class ReferenceDataServiceImpl
    {
        private ReferenceDataRepository repository;

        public ReferenceDataServiceImpl()
        {
            repository = new ReferenceDataRepository();
        }

        public IList<PhoneType> GetPhoneTypes()
        {
            return repository.LoadAll<PhoneType>();
        }
    }
}