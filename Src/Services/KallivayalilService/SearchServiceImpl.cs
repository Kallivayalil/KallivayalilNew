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
        private readonly OccupationRepository occupationRepository;


        public SearchServiceImpl(ConstituentRepository constituentRepository, EmailRepository emailRepository, PhoneRepository phoneRepository, OccupationRepository occupationRepository)
        {
            this.constituentRepository = constituentRepository;
            this.occupationRepository = occupationRepository;
            this.phoneRepository = phoneRepository;
            this.emailRepository = emailRepository;
        }

        public IList<Constituent> Search(string firstName, string lastName, string email, string phone, string occupationName, string occupationDescription)
        {
            var constituentsWithNameMatch = constituentRepository.SearchByConstituentName(firstName, lastName);
            var constituentsWithEmailMatch = emailRepository.SearchByEmail(email);
            var constituentsWithPhoneMatch = phoneRepository.SearchByNumber(phone);
            var constituentsWithOccupationMatch = occupationRepository.SearchOccupationBy(occupationName,occupationDescription);

            return constituentsWithNameMatch.Union(constituentsWithEmailMatch.Union(constituentsWithPhoneMatch.Union(constituentsWithOccupationMatch))).ToList();
        }

        public Constituent SearchBy(string emailId)
        {
            var email = emailRepository.Load(emailId);
            return email.Constituent;
        }
    }
}