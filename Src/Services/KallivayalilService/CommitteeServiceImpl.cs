using System;
using System.Collections.Generic;
using Kallivayalil.Common;
using Kallivayalil.DataAccess.Repositories;
using Kallivayalil.Domain;
using Kallivayalil.Domain.ReferenceData;

namespace Kallivayalil
{
    public class CommitteeServiceImpl 
    {
        private readonly CommitteeRepository repository;

        public CommitteeServiceImpl(CommitteeRepository repository) 
        {
            this.repository = repository;
        }

        public Committee CreateCommittee(Committee committee)
        {
            LoadPositionType(committee);
            return repository.Save(committee);
        }

        private void LoadPositionType(Committee committee)
        {
            if (Entity.IsNull(committee.Type))
            {
                throw new BadRequestException("AddressType can not be null");
            }
            committee.Type = repository.Load<PositionType>(committee.Type.Id);
        }

        public Committee UpdateCommittee(Committee committee)
        {
            LoadPositionType(committee);
            return repository.Update(committee);
        }

        public void DeleteCommittee(string id)
        {
            repository.Delete(Convert.ToInt32(id));
        }

        public IList<Committee> FindCommittees()
        {
            return repository.LoadAll<Committee>();
        }

        public Committee FindCommittee(string id)
        {
            return repository.Load(Convert.ToInt32(id));
        }


    }
}