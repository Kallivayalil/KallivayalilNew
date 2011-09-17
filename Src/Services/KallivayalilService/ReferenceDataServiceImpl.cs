using System;
using System.Collections;
using System.Collections.Generic;
using Kallivayalil.DataAccess.Repositories;
using Kallivayalil.Domain.ReferenceData;

namespace Kallivayalil
{
    public class ReferenceDataServiceImpl
    {
        private readonly ReferenceDataRepository repository;

        public ReferenceDataServiceImpl(ReferenceDataRepository repository)
        {
            this.repository = repository;
        }

        public IList<PhoneType> GetPhoneTypes()
        {
            return repository.LoadAll<PhoneType>();
        }

        public IList<OccupationType> GetOccupationTypes()
        {
            return repository.LoadAll<OccupationType>();
        }

        public IList<EducationType> GetEducationTypes()
        {
            return repository.LoadAll<EducationType>();
        }

        public IList<EmailType> GetEmailTypes()
        {
            return repository.LoadAll<EmailType>();
        }

        public IList<AddressType> GetAddressTypes()
        {
            return repository.LoadAll<AddressType>();
        }

        public IList<SalutationType> GetSaluationTypes()
        {
            return repository.LoadAll<SalutationType>();
        }

        public IList<AssociationType> GetAssociationTypes()
        {
            return repository.LoadAll<AssociationType>();
        } 
        
        public IList<BranchType> GetBranchTypes()
        {
            return repository.LoadAll<BranchType>();
        }

        public IList<EventType> EventTypes()
        {
            return repository.LoadAll<EventType>();
        }
    }
}