using System.Collections.Generic;
using Kallivayalil.DataAccess.Repositories;
using Kallivayalil.Domain;

namespace Kallivayalil
{
    public class SearchServiceImpl
    {
        private readonly ConstituentNameRepository nameRepository;
        private readonly ConstituentRepository constituentRepository;


        public SearchServiceImpl(ConstituentNameRepository constituentNameRepository, ConstituentRepository constituentRepository)
        {
            nameRepository = constituentNameRepository;
            this.constituentRepository = constituentRepository;
        }

        public IEnumerable<Constituent> SearchByConstituentName(string firstName, string lastName)
        {
            var nameIds = nameRepository.SearchByName(firstName, lastName);

            return constituentRepository.FetchConstituentByConstituentName(nameIds);
        }
    }
}