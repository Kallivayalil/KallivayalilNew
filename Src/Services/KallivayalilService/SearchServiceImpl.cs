using System.Collections.Generic;
using Kallivayalil.DataAccess.Repositories;
using Kallivayalil.Domain;

namespace Kallivayalil
{
    public class SearchServiceImpl
    {
        private readonly ConstituentRepository constituentRepository;


        public SearchServiceImpl(ConstituentRepository constituentRepository)
        {
            this.constituentRepository = constituentRepository;
        }

        public IEnumerable<Constituent> SearchByConstituentName(string firstName, string lastName)
        {
            return constituentRepository.SearchByName(firstName, lastName);
        }
    }
}