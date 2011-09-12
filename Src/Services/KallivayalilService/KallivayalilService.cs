using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.ServiceModel;
using System.ServiceModel.Activation;
using Kallivayalil.Client;
using Kallivayalil.Common;
using Kallivayalil.DataAccess.Repositories;
using Kallivayalil.Domain;
using Kallivayalil.Utility;

namespace Kallivayalil
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class KallivayalilService : IKallivayalilService
    {
        private readonly ConstituentServiceImpl constituentServiceImpl;
        private readonly RegistrationServiceImpl registrationServiceImpl;
        private readonly ConstituentNameServiceImpl nameServiceImpl;
        private readonly AutoDataContractMapper mapper;
        private readonly AddressServiceImpl addressServiceImpl;
        private readonly PhoneServiceImpl phoneServiceImpl;
        private readonly EmailServiceImpl emailServiceImpl;
        private readonly OccupationServiceImpl occupationServiceImpl;
        private readonly EducationDetailServiceImpl educationalDetailServiceImpl;
        private readonly ReferenceDataServiceImpl referenceDataServiceImpl;
        private readonly LoginServiceImpl loginServiceImpl;
        private readonly SearchServiceImpl searchServiceImpl;
        private readonly AssociationServiceImpl associationServiceImpl;
        private readonly EventServiceImpl eventServiceImpl;
        private readonly ContactUsServiceImpl contactUsServiceImpl;

        public KallivayalilService()
        {
//            HibernatingRhinos.Profiler.Appender.NHibernate.NHibernateProfiler.Initialize();
            var constituentNameRepository = new ConstituentNameRepository();
            var constituentRepository = new ConstituentRepository();
            var referenceDataRepository = new ReferenceDataRepository();
            var educationDetailRepository = new EducationDetailRepository();
            var eventRepository = new EventRepository();
            var contactUsRepository = new ContactUsRepository();
            var registerationRepository = new RegisterationRepository();

            constituentServiceImpl = new ConstituentServiceImpl(constituentRepository);
            registrationServiceImpl = new RegistrationServiceImpl(registerationRepository, new Mail(new SmtpClient()));
            contactUsServiceImpl = new ContactUsServiceImpl(contactUsRepository);
            nameServiceImpl = new ConstituentNameServiceImpl(constituentNameRepository);
            addressServiceImpl = new AddressServiceImpl(new AddressRepository());
            phoneServiceImpl = new PhoneServiceImpl(new PhoneRepository(), constituentRepository);
            var emailRepository = new EmailRepository();
            emailServiceImpl = new EmailServiceImpl(emailRepository);
            loginServiceImpl = new LoginServiceImpl();
            occupationServiceImpl = new OccupationServiceImpl(new OccupationRepository(), constituentRepository);
            educationalDetailServiceImpl = new EducationDetailServiceImpl(educationDetailRepository, constituentRepository);
            associationServiceImpl = new AssociationServiceImpl(new AssociationRepository());
            searchServiceImpl = new SearchServiceImpl(constituentRepository, emailRepository);
            eventServiceImpl = new EventServiceImpl(eventRepository, constituentRepository, referenceDataRepository);
            mapper = new AutoDataContractMapper();
            referenceDataServiceImpl = new ReferenceDataServiceImpl(referenceDataRepository);
        }

        public virtual ConstituentData GetConstituent(string id)
        {
            var constituent = constituentServiceImpl.FindConstituent(id);
            var constituentData = new ConstituentData();
            if (constituent == null)
            {
                throw new NotFoundException(string.Format("Constituent with Id:{0} not found.", id));
            }
            mapper.Map(constituent, constituentData);
            return constituentData;
        }

        public virtual ConstituentsData GetConstituents()
        {
            var constituents = constituentServiceImpl.GetAllConstituents();

            var constituentsData = new ConstituentsData();
            mapper.MapList(constituents, constituentsData, typeof (ConstituentData));

            return constituentsData;
        }

        public virtual void DeleteConstituent(string id)
        {
            constituentServiceImpl.DeleteConstituent(id);
        }

        public virtual ConstituentData CreateConstituent(ConstituentData constituentData)
        {
            var constituent = new Constituent();
            mapper.Map(constituentData, constituent);
            Constituent savedConstituent = constituentServiceImpl.CreateConstituent(constituent);
            var savedConstituentData = new ConstituentData();
            mapper.Map(savedConstituent, savedConstituentData);
            return savedConstituentData;
        }

        public virtual RegisterationData CreateRegistrationConstituent(RegisterationData registerationData)
        {
            var registerationConstituent = new RegisterationConstituent();
            mapper.Map(registerationData, registerationConstituent);
            var savedRegistrationConstituent = registrationServiceImpl.CreateRegistrationConstituent(registerationConstituent);
            var savedData = new RegisterationData();
            mapper.Map(savedRegistrationConstituent, savedData);
            return savedData;
        }

        public virtual ConstituentData UpdateConstituent(string id, ConstituentData constituentData)
        {
            var constituent = new Constituent();
            mapper.Map(constituentData, constituent);
            Constituent updatedConstituent = constituentServiceImpl.UpdateConstituent(id, constituent);
            var updateConstiuentData = new ConstituentData();
            mapper.Map(updatedConstituent, updateConstiuentData);
            return updateConstiuentData;
        }

        public virtual ConstituentNameData UpdateConstituentName(string id, ConstituentNameData nameData)
        {
            var constituentName = new ConstituentName();
            mapper.Map(nameData, constituentName);
            var updatedName = nameServiceImpl.UpdateConstituentName(id, constituentName);

            var updatedNameData = new ConstituentNameData();
            mapper.Map(updatedName, updatedNameData);

            return updatedNameData;
        }

        public virtual SearchResultsData SearchByConstituentName(string firstName, string lastName)
        {
            var allConstituents = searchServiceImpl.SearchByConstituentName(firstName, lastName);

  SearchResultsData searchResultsData = GetSearchResultData(allConstituents);
            var searchDatas = new SearchResultsData();
            mapper.MapList(allConstituents, searchDatas, typeof(SearchResultData));

            return searchDatas;
        }

        public virtual ConstituentData SearchByEmailId(string emailId)
        {
            var constituent = searchServiceImpl.SearchBy(emailId);

            var constituentData = new ConstituentData();
            mapper.Map(constituent, constituentData);

            return constituentData;
        }

        public virtual AddressData CreateAddress(string constituentId, AddressData addressData)
        {
            var address = new Address();
            mapper.Map(addressData, address);

            var savedAddress = addressServiceImpl.CreateAddress(address);
            var savedAddressData = new AddressData();
            mapper.Map(savedAddress, savedAddressData);
            return savedAddressData;
        }

        public virtual AddressData UpdateAddress(string id, AddressData addressData)
        {
            var address = new Address();
            mapper.Map(addressData, address);

            var savedAddress = addressServiceImpl.UpdateAddress(address);
            var savedAddressData = new AddressData();
            mapper.Map(savedAddress, savedAddressData);
            return savedAddressData;
        }

        public virtual void DeleteAddress(string id)
        {
            addressServiceImpl.DeleteAddress(id);
        }

        public virtual AddressData GetAddress(string id)
        {
            var address = addressServiceImpl.FindAddress(id);
            var addressData = new AddressData();
            if (address == null)
            {
                throw new NotFoundException(string.Format("Address with Id:{0} not found.", id));
            }
            mapper.Map(address, addressData);
            return addressData;
        }

        public virtual AddressesData GetAddresses(string constituentId)
        {
            var addresses = addressServiceImpl.FindAddresses(constituentId);

            var addressesData = new AddressesData();
            mapper.MapList(addresses, addressesData, typeof (AddressData));

            return addressesData;
        }

        public virtual PhoneData CreatePhone(string constituentId, PhoneData phoneData)
        {
            var phone = new Phone();
            mapper.Map(phoneData, phone);
            var savedPhone = phoneServiceImpl.CreatePhone(phone);

            var savedPhoneData = new PhoneData();

            mapper.Map(savedPhone, savedPhoneData);

            return savedPhoneData;
        }

        public virtual PhoneData UpdatePhone(string id, PhoneData phoneData)
        {
            var phone = new Phone();
            mapper.Map(phoneData, phone);

            var updatedPhone = phoneServiceImpl.UpdatePhone(phone);
            var updatedPhoneData = new PhoneData();
            mapper.Map(updatedPhone, updatedPhoneData);

            return updatedPhoneData;
        }

        public virtual PhoneData GetPhone(string id)
        {
            var phone = phoneServiceImpl.FindPhone(id);
            var phoneData = new PhoneData();

            if (phone == null)
            {
                throw new NotFoundException(string.Format("Phone with Id:{0} not found.", id));
            }

            mapper.Map(phone, phoneData);

            return phoneData;
        }

        public virtual void DeletePhone(string id)
        {
            phoneServiceImpl.DeletePhone(id);
        }

        public virtual PhonesData GetPhones(string constituentId)
        {
            var phones = phoneServiceImpl.FindPhones(constituentId);

            var phonesData = new PhonesData();
            mapper.MapList(phones, phonesData, typeof (PhoneData));
            return phonesData;
        }

        public virtual EmailData CreateEmail(string constituentId, EmailData emailData)
        {
            var email = new Email();
            mapper.Map(emailData, email);
            var savedEmail = emailServiceImpl.CreateEmail(email);

            var savedEmailData = new EmailData();

            mapper.Map(savedEmail, savedEmailData);

            return savedEmailData;
        }

        public virtual EmailData UpdateEmail(string id, EmailData emailData)
        {
            var email = new Email();
            mapper.Map(emailData, email);

            var updatedEmail = emailServiceImpl.UpdateEmail(email);
            var updatedEmailData = new EmailData();
            mapper.Map(updatedEmail, updatedEmailData);

            return updatedEmailData;
        }

        public virtual EmailData GetEmail(string id)
        {
            var email = emailServiceImpl.FindEmail(id);
            var emailData = new EmailData();

            if (email == null)
            {
                throw new NotFoundException(string.Format("Email with Id:{0} not found.", id));
            }

            mapper.Map(email, emailData);

            return emailData;
        }

        public virtual void DeleteEmail(string id)
        {
            emailServiceImpl.DeleteEmail(id);
        }

        public virtual EmailsData GetEmails(string constituentId)
        {
            var emails = emailServiceImpl.FindEmails(constituentId);

            var emailData = new EmailsData();
            mapper.MapList(emails, emailData, typeof (EmailData));
            return emailData;
        }

        public virtual EducationDetailData CreateEducationDetail(string constituentId, EducationDetailData educationDetailData)
        {
            var educationDetail = new EducationDetail();
            mapper.Map(educationDetailData, educationDetail);
            var saveEducationDetail = educationalDetailServiceImpl.CreateEducationDetail(educationDetail);

            var savedEducationDetail = new EducationDetailData();

            mapper.Map(saveEducationDetail, savedEducationDetail);

            return savedEducationDetail;
        }

        public virtual EducationDetailData UpdateEducationDetail(string id, EducationDetailData educationDetailData)
        {
            var educationDetail = new EducationDetail();
            mapper.Map(educationDetailData, educationDetail);

            var updateEducationDetail = educationalDetailServiceImpl.UpdateEducationDetail(educationDetail);
            var updatedEducationalDetail = new EducationDetailData();
            mapper.Map(updateEducationDetail, updatedEducationalDetail);

            return updatedEducationalDetail;
        }

        public virtual EducationDetailData GetEducationDetail(string id)
        {
            var educationDetail = educationalDetailServiceImpl.FindEducationDetail(id);
            var educationalDetailData = new EducationDetailData();

            if (educationDetail == null)
            {
                throw new NotFoundException(string.Format("Educational Detail with Id:{0} not found.", id));
            }
            mapper.Map(educationDetail, educationalDetailData);

            return educationalDetailData;
        }

        public virtual void DeleteEducationDetail(string id)
        {
            educationalDetailServiceImpl.DeleteEducationDetail(id);
        }

        public virtual EducationDetailsData GetEducationDetails(string constituentId)
        {
            var educationDetails = educationalDetailServiceImpl.FindEducationDetails(constituentId);

            var educationalDetailsData = new EducationDetailsData();
            mapper.MapList(educationDetails, educationalDetailsData, typeof (EducationDetailData));
            return educationalDetailsData;
        }

        public virtual OccupationData CreateOccupation(string constituentId, OccupationData occupationData)
        {
            var occupation = new Occupation();
            mapper.Map(occupationData, occupation);
            var savedOccupation = occupationServiceImpl.CreateOccupation(occupation);

            var savedOccupationData = new OccupationData();

            mapper.Map(savedOccupation, savedOccupationData);

            return savedOccupationData;
        }

        public virtual OccupationData UpdateOccupation(string id, OccupationData occupationData)
        {
            var occupation = new Occupation();
            mapper.Map(occupationData, occupation);

            var updatedOccupation = occupationServiceImpl.UpdateOccupation(occupation);
            var updatedOccupationData = new OccupationData();
            mapper.Map(updatedOccupation, updatedOccupationData);

            return updatedOccupationData;
        }

        public virtual OccupationData GetOccupation(string id)
        {
            var occupation = occupationServiceImpl.FindOccupation(id);
            var occupationData = new OccupationData();

            if (occupation == null)
            {
                throw new NotFoundException(string.Format("Email with Id:{0} not found.", id));
            }

            mapper.Map(occupation, occupationData);

            return occupationData;
        }

        public virtual void DeleteOccupation(string id)
        {
            occupationServiceImpl.DeleteOccupation(id);
        }

        public virtual OccupationsData GetOccupations(string constituentId)
        {
            var occupations = occupationServiceImpl.FindOccupations(constituentId);
            var occupationData = new OccupationsData();
            mapper.MapList(occupations, occupationData, typeof (OccupationData));
            return occupationData;
        }

        public virtual AssociationData CreateAssociation(string constituentId, AssociationData associationData)
        {
            var association = new Association();
            mapper.Map(associationData, association);
            var savedAssociation = associationServiceImpl.CreateAssociation(association);

            var savedAssociationData = new AssociationData();

            mapper.Map(savedAssociation, savedAssociationData);

            return savedAssociationData;
        }

        public virtual AssociationData UpdateAssociation(string id, AssociationData associationData)
        {
            var association = new Association();
            mapper.Map(associationData, association);

            var updatedAssociation = associationServiceImpl.UpdateAssociation(association);
            var updatedAssociationData = new AssociationData();
            mapper.Map(updatedAssociation, updatedAssociationData);

            return updatedAssociationData;
        }

        public virtual AssociationData GetAssociation(string id)
        {
            var association = associationServiceImpl.FindAssociation(id);
            var associationData = new AssociationData();

            if (association == null)
            {
                throw new NotFoundException(string.Format("Association with Id:{0} not found.", id));
            }

            mapper.Map(association, associationData);

            return associationData;
        }

        public virtual void DeleteAssociation(string id)
        {
            associationServiceImpl.DeleteAssociation(id);
        }

        public virtual AssociationsData GetAssociations(string constituentId)
        {
            var associations = associationServiceImpl.FindAssociations(constituentId);

            var associationsData = new AssociationsData();
            mapper.MapList(associations, associationsData, typeof (AssociationData));

            return associationsData;
        }

        public virtual RelationshipData GetRelationships(string constituentId)
        {
            var associations = associationServiceImpl.FindAssociations(constituentId);

            var parents = associations.ToList().FindAll(assn => assn.Type.Id.Equals(2) && assn.Constituent.Id != Convert.ToInt32(constituentId));
            var spouse = associations.ToList().Find(assn => assn.Type.Id.Equals(1));
            var childs = associations.ToList().FindAll(assn => assn.Type.Id.Equals(3) && assn.Constituent.Id != Convert.ToInt32(constituentId));
            var sibilings = associations.ToList().FindAll(assn => assn.Type.Id.Equals(4));

            var parentFamily = GetFamilyRelationship(parents[0].Constituent, parents[1].Constituent,"top");
            RelationshipData myFamily = null;
            parentFamily.children = new List<RelationshipData>();

            foreach (var sibiling in sibilings)
            {
                var dat = new TreeData();
                dat.orientation = "top";
                parentFamily.children.Add(new RelationshipData {id = sibiling.Constituent.Name.ToString(), name = sibiling.Constituent.Name.ToString(),data = dat});
            }

            if (spouse != null)
            {
                var dat = new TreeData();
                dat.orientation = "top";
                myFamily = GetFamilyRelationship(spouse.AssociatedConstituent, spouse.Constituent,"center");
                myFamily.data = dat;
            }

            if (myFamily != null)
            {
                myFamily.children = new List<RelationshipData>();
                foreach (var child in childs)
                {
                    var dat = new TreeData();
                    dat.orientation = "top";
                    myFamily.children.Add(new RelationshipData { id = child.Constituent.Name.ToString(), data = dat, name = child.Constituent.Name.ToString() });
                }
            }

            parentFamily.children.Add(myFamily);
            return parentFamily;
        }

        private RelationshipData GetFamilyRelationship(Constituent familyMember, Constituent spouse, string orientation = null)
        {
            var name = familyMember.Name.ToString();
            var data =new TreeData();
            data.type = "family";
            data.spouse= spouse.Name.ToString();
            if (orientation != null)
            {
                data.orientation = orientation;
            }
            return new RelationshipData {id = name, name = name, children = new List<RelationshipData>(), data = data};
        }

        public virtual EventData CreateEvent(EventData eventData)
        {
            var @event = new Event();
            mapper.Map(eventData, @event);
            var savedEvent = eventServiceImpl.CreateEvent(@event);

            var savedEventData = new EventData();

            mapper.Map(savedEvent, savedEventData);

            return savedEventData;
        }

        public virtual ContactUsData CreateFeedback(ContactUsData feedbackData)
        {
            var contactUs = new ContactUs();
            mapper.Map(feedbackData, contactUs);
            var savedContactUs = contactUsServiceImpl.CreateContactUs(contactUs);

            var contactUsData = new ContactUsData();

            mapper.Map(savedContactUs, contactUsData);

            return contactUsData;
        }

        public virtual EventData UpdateEvent(string id, EventData eventData)
        {
            var @event = new Event();
            mapper.Map(eventData, @event);

            var updatedEvent = eventServiceImpl.UpdateEvent(@event);
            var updatedEventData = new EventData();
            mapper.Map(updatedEvent, updatedEventData);

            return updatedEventData;
        }

        public virtual EventData GetEvent(string id)
        {
            var @event = eventServiceImpl.FindEvent(id);
            var eventData = new EventData();

            if (@event == null)
            {
                throw new NotFoundException(string.Format("Event with Id:{0} not found.", id));
            }

            mapper.Map(@event, eventData);

            return eventData;
        }

        public virtual void DeleteEvent(string id)
        {
            eventServiceImpl.DeletEvent(id);
        }

        public virtual EventsData GetEvents(string isApproved, string startDate, string endDate, string includeBirthdaysAndAnniversary)
        {
            var events = eventServiceImpl.FindEvents(bool.Parse(isApproved), DateTime.Parse(startDate), DateTime.Parse(endDate), bool.Parse(includeBirthdaysAndAnniversary));

            var eventsData = new EventsData();
            mapper.MapList(events, eventsData, typeof (EventData));
            return eventsData;
        }

        public virtual OccupationTypesData GetOccupationTypes()
        {
            var types = referenceDataServiceImpl.GetOccupationTypes();

            var occupationTypes = new OccupationTypesData();
            mapper.MapList(types, occupationTypes, typeof (OccupationTypeData));
            return occupationTypes;
        }

        public virtual EducationTypesData GetEducationTypes()
        {
            var types = referenceDataServiceImpl.GetEducationTypes();

            var educationTypesData = new EducationTypesData();
            mapper.MapList(types, educationTypesData, typeof (EducationTypeData));
            return educationTypesData;
        }


        public virtual PhoneTypesData GetPhoneTypes()
        {
            var types = referenceDataServiceImpl.GetPhoneTypes();

            var phoneTypes = new PhoneTypesData();
            mapper.MapList(types, phoneTypes, typeof (PhoneTypeData));
            return phoneTypes;
        }

        public virtual EmailTypesData GetEmailTypes()
        {
            var emailTypes = referenceDataServiceImpl.GetEmailTypes();

            var emailTypesData = new EmailTypesData();
            mapper.MapList(emailTypes, emailTypesData, typeof (EmailTypeData));
            return emailTypesData;
        }

        public virtual AddressTypesData GetAddressTypes()
        {
            var types = referenceDataServiceImpl.GetAddressTypes();
            var addressTypes = new AddressTypesData();
            mapper.MapList(types, addressTypes, typeof (AddressTypeData));
            return addressTypes;
        }

        public virtual SalutationTypesData GetSalutationTypes()
        {
            var types = referenceDataServiceImpl.GetSaluationTypes();
            var salutationTypes = new SalutationTypesData();
            mapper.MapList(types, salutationTypes, typeof (SalutationTypeData));
            return salutationTypes;
        }

        public virtual AssociationTypesData GetAssociationTypes()
        {
            var types = referenceDataServiceImpl.GetAssociationTypes();
            var associationTypes = new AssociationTypesData();
            mapper.MapList(types, associationTypes, typeof (AssociationTypeData));
            return associationTypes;
        }

        public virtual EventTypesData GetEventTypes()
        {
            var types = referenceDataServiceImpl.EventTypes();
            var eventTypesData = new EventTypesData();
            mapper.MapList(types, eventTypesData, typeof (EventTypeData));
            return eventTypesData;
        }

        public virtual bool Authenticate(string username, string password)
        {
            return loginServiceImpl.Authenticate(username, password);
        }
    }
}