using System;
using System.Collections.Generic;
using Kallivayalil.DataAccess.Repositories;
using Kallivayalil.Domain;

namespace Kallivayalil
{
    public class SearchServiceImpl
    {
        private readonly ConstituentRepository constituentRepository;
        private readonly EmailRepository emailRepository;


        public SearchServiceImpl(ConstituentRepository constituentRepository, EmailRepository emailRepository)
        {
            this.constituentRepository = constituentRepository;
            this.emailRepository = emailRepository;
        }

        public IList<Constituent> SearchByConstituentName(string firstName, string lastName)
        {
            return SearchQueryParamsExist(firstName,lastName) ? constituentRepository.SearchByConstituentName(firstName, lastName) : new List<Constituent>();
        }

        private bool SearchQueryParamsExist(string firstName, string lastName)
        {
            return !(string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName));
        }

        public Constituent SearchBy(string emailId)
        {
            var email = emailRepository.Load(emailId);
            return email.Constituent;
        }
    }
}