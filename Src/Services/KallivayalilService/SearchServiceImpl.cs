using System;
using System.Collections.Generic;
using Kallivayalil.DataAccess.Repositories;
using Kallivayalil.Domain;
using System.Linq;
using FluentValidation.Internal;

namespace Kallivayalil
{
    public class SearchServiceImpl
    {
        private readonly ConstituentRepository constituentRepository;
        private readonly EmailRepository emailRepository;
        private readonly PhoneRepository phoneRepository;
        private readonly OccupationRepository occupationRepository;
        private readonly EducationDetailRepository educationDetailRepository;
        private readonly AddressRepository addressRepository;


        public SearchServiceImpl(ConstituentRepository constituentRepository, EmailRepository emailRepository, PhoneRepository phoneRepository, OccupationRepository occupationRepository, EducationDetailRepository educationDetailRepository, AddressRepository addressRepository)
        {
            this.constituentRepository = constituentRepository;
            this.addressRepository = addressRepository;
            this.educationDetailRepository = educationDetailRepository;
            this.occupationRepository = occupationRepository;
            this.phoneRepository = phoneRepository;
            this.emailRepository = emailRepository;
        }

        public List<Constituent> Search(string firstName, string lastName, string email, string phone, string occupationName, string occupationDescription, string instituteName, string instituteLocation, string qualification, string yearOfGradutation, string address, string state, string city, string country, string postcode, string preferedName, string houseName, string branch, bool matchAllCriteria)
        {
            var constituentsWithNameMatch = SearchConstituentsWithName(firstName,lastName,preferedName)  ? constituentRepository.SearchByConstituentName(firstName, lastName, preferedName, matchAllCriteria) : null;
            var constituentsWithEmailMatch = !string.IsNullOrEmpty(email) ? emailRepository.SearchByEmail(email):null;
            var constituentsWithPhoneMatch = !string.IsNullOrEmpty(phone) ? phoneRepository.SearchByNumber(phone) : null;
            var constituentsWithOccupationMatch = SearchConstituentsByOccupation(occupationName,occupationDescription) ? occupationRepository.SearchOccupationBy(occupationName, occupationDescription, matchAllCriteria) : null;
            var constituentsWithEducationDetailMatch = SearchConstituentsByEducation(instituteName,instituteLocation,qualification,yearOfGradutation) ? educationDetailRepository.SearchEducationDetailBy(instituteName, instituteLocation, qualification, yearOfGradutation, matchAllCriteria):null;
            var constituentsWithAddressMatch = SearchConstituentsByAddress(address,state,city,country,postcode) ? addressRepository.SearchAddressBy(address, state, city, country, postcode, matchAllCriteria) : null;
            var constituentsWithBranchMatch = !string.IsNullOrEmpty(branch) ? constituentRepository.SearchByConstituentBranch(branch) : null;
            var constituentsWithHouseNameMatch = !string.IsNullOrEmpty(houseName) ?constituentRepository.SearchByConstituentHouseName(houseName) : null;

            return GetConstituents(matchAllCriteria,constituentsWithNameMatch, constituentsWithEmailMatch, constituentsWithPhoneMatch, constituentsWithOccupationMatch, constituentsWithEducationDetailMatch, constituentsWithAddressMatch, constituentsWithBranchMatch, constituentsWithHouseNameMatch);
        }

        private bool SearchConstituentsWithName(string firstName, string lastName, string preferedName)
        {
            return !string.IsNullOrEmpty(firstName) || !string.IsNullOrEmpty(lastName) || !string.IsNullOrEmpty(preferedName);
        }

        private bool SearchConstituentsByOccupation(string occupationName, string occupationDescription)
        {
            return !string.IsNullOrEmpty(occupationName) || !string.IsNullOrEmpty(occupationDescription) ;
        }

        private bool SearchConstituentsByEducation(string instituteName, string instituteLocation, string qualification, string yearOfGradutation)
        {
            return !string.IsNullOrEmpty(instituteName) || !string.IsNullOrEmpty(instituteLocation) || !string.IsNullOrEmpty(qualification) || !string.IsNullOrEmpty(yearOfGradutation);
        }

        private bool SearchConstituentsByAddress(string address, string state, string city, string country, string postcode)
        {
            return !string.IsNullOrEmpty(address) || !string.IsNullOrEmpty(state) || !string.IsNullOrEmpty(city) || !string.IsNullOrEmpty(country) || !string.IsNullOrEmpty(postcode);
        }

        private List<Constituent> GetConstituents(bool matchAllCriteria,params List<Constituent>[] constituentsWithMatch)
        {
            var resultList = new List<Constituent>();
            if (matchAllCriteria)
            {
                constituentsWithMatch.ForEach(list =>
                                                  {
                                                      if ( list!=null)
                                                      {
                                                          if(resultList.Count == 0)
                                                            resultList = list;
                                                          resultList = resultList.Intersect(list).ToList();
                                                      }

                                                  });
            }
            else
            {
                constituentsWithMatch.ForEach(list => { if(list!=null) resultList = resultList.Union(list).ToList(); });
                
            }
            return resultList.ToList();
        }

        public Constituent SearchBy(string emailId)
        {
            var email = emailRepository.Load(emailId);
            return email.Constituent;
        }
    }
}