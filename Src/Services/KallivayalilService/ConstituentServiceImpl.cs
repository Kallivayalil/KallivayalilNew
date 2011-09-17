using System;
using System.Collections;
using Kallivayalil.Common;
using Kallivayalil.DataAccess.Repositories;
using Kallivayalil.Domain;
using Kallivayalil.Domain.ReferenceData;

namespace Kallivayalil
{
    public class ConstituentServiceImpl
    {
        private readonly ConstituentRepository repository;


        public ConstituentServiceImpl(ConstituentRepository repository)
        {
            this.repository = repository;
        }

        public Constituent FindConstituent(string id)
        {
            return repository.Load(Convert.ToInt32(id));
        }

        public Constituent CreateConstituent(Constituent constituent)
        {
            LoadBranchType(constituent);
            return repository.Save(constituent);
        }

        private void LoadBranchType(Constituent constituent)
        {
            if (Entity.IsNull(constituent.BranchName))
            {
                throw new BadRequestException("AddressType can not be null");
            }
            constituent.BranchName = repository.Load<BranchType>(constituent.BranchName.Id);
        }

        public Constituent UpdateConstituent(string id, Constituent constituent)
        {
            if (repository.Exists<Constituent>(Convert.ToInt32(id)))
            {
                LoadBranchType(constituent);
                return repository.Update(constituent);
            }
            return null;
        }

        public void DeleteConstituent(string id)
        {
            repository.Delete(Convert.ToInt32(id));
        }

        public IEnumerable GetAllConstituents()
        {
            return repository.LoadAll<Constituent>();
        }

       
    }
}