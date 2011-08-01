using System;
using System.Collections;
using System.Collections.Generic;
using Kallivayalil.DataAccess.Repositories;
using Kallivayalil.Domain;

namespace Kallivayalil
{
    public class ConstituentServiceImpl
    {
        private readonly ConstituentRepository repository;


        public ConstituentServiceImpl()
        {
            repository = new ConstituentRepository();
        }

        public Constituent FindConstituent(string id)
        {
            return repository.Load(Convert.ToInt32(id));
        }

        public Constituent CreateConstituent(Constituent constituent)
        {
            return repository.Save(constituent);
        }

        public Constituent UpdateConstituent(string id, Constituent constituent)
        {
            if (repository.Exists<Constituent>(Convert.ToInt32(id)))
            {
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

        public IEnumerable<Constituent> GetAllConstituents(IList nameIds)
        {
            return repository.FetchConstituentByConstituentName(nameIds);
        }
    }
}