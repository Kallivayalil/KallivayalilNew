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
        private readonly EducationDetailRepository educationDetailRepository;


        public SearchServiceImpl(ConstituentRepository constituentRepository, EmailRepository emailRepository, PhoneRepository phoneRepository, OccupationRepository occupationRepository, EducationDetailRepository educationDetailRepository)
        {
            this.constituentRepository = constituentRepository;
            this.educationDetailRepository = educationDetailRepository;
            this.occupationRepository = occupationRepository;
            this.phoneRepository = phoneRepository;
            this.emailRepository = emailRepository;
        }

        public IList<Constituent> Search(string firstName, string lastName, string email, string phone, string occupationName, string occupationDescription, string instituteName, string instituteLocation, string qualification, string yearOfGradutation)
        {
            var constituentsWithNameMatch = constituentRepository.SearchByConstituentName(firstName, lastName);
            var constituentsWithEmailMatch = emailRepository.SearchByEmail(email);
            var constituentsWithPhoneMatch = phoneRepository.SearchByNumber(phone);
            var constituentsWithOccupationMatch = occupationRepository.SearchOccupationBy(occupationName,occupationDescription);
            var constituentsWithEducationDetailMatch = educationDetailRepository.SearchEducationDetailBy(instituteName,instituteLocation,qualification,yearOfGradutation);

            return constituentsWithNameMatch.Union(
                        constituentsWithEmailMatch.Union(
                            constituentsWithPhoneMatch.Union(
                                constituentsWithOccupationMatch.Union(
                                    constituentsWithEducationDetailMatch)))).ToList();
        }

        public Constituent SearchBy(string emailId)
        {
            var email = emailRepository.Load(emailId);
            return email.Constituent;
        }
    }
}