using System;
using System.Collections.Generic;
using Kallivayalil.DataAccess.Repositories;
using Kallivayalil.Domain;
using System.Linq;

namespace Kallivayalil
{
    public class SearchServiceImpl
    {
        private readonly ConstituentRepository constituentRepository;
        private readonly EmailRepository emailRepository;
        private readonly PhoneRepository phoneRepository;


        public SearchServiceImpl(ConstituentRepository constituentRepository, EmailRepository emailRepository, PhoneRepository phoneRepository)
        {
            this.constituentRepository = constituentRepository;
            this.phoneRepository = phoneRepository;
            this.emailRepository = emailRepository;
        }

        public IList<Constituent> Search(string firstName, string lastName, string email, string phone)
        {
            var constituentsWithNameMatch = constituentRepository.SearchByConstituentName(firstName, lastName);
            var constituentsWithEmailMatch = emailRepository.SearchByEmail(email);
            var constituentsWithPhoneMatch = phoneRepository.SearchByNumber(phone);

            return constituentsWithNameMatch.Union(constituentsWithEmailMatch.Union(constituentsWithPhoneMatch)).ToList();
        }

        public Constituent SearchBy(string emailId)
        {
            var email = emailRepository.Load(emailId);
            return email.Constituent;
        }
    }
}