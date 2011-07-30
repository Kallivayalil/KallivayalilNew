using System.ServiceModel;
using System.ServiceModel.Activation;
using Kallivayalil.Client;
using Kallivayalil.Common;
using Kallivayalil.DataAccess.Repositories;
using Kallivayalil.Domain;

namespace Kallivayalil
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class KallivayalilService : IKallivayalilService
    {
        private readonly ConstituentServiceImpl constituentServiceImpl;
        private readonly ConstituentNameServiceImpl nameServiceImpl;
        private readonly AutoDataContractMapper mapper;
        private readonly AddressServiceImpl addressServiceImpl;
        private readonly PhoneServiceImpl phoneServiceImpl;
        private readonly EmailServiceImpl emailServiceImpl;
        private readonly OccupationServiceImpl occupationServiceImpl;
        private readonly EducationDetailServiceImpl educationalDetailServiceImpl;
        private readonly ReferenceDataServiceImpl referenceDataServiceImpl;
        private readonly LoginServiceImpl loginServiceImpl;

        public KallivayalilService()
        {
            constituentServiceImpl = new ConstituentServiceImpl();
            nameServiceImpl = new ConstituentNameServiceImpl();
            addressServiceImpl = new AddressServiceImpl(new AddressRepository());
            phoneServiceImpl = new PhoneServiceImpl();
            emailServiceImpl = new EmailServiceImpl();
            loginServiceImpl = new LoginServiceImpl();
            occupationServiceImpl = new OccupationServiceImpl();
            educationalDetailServiceImpl = new EducationDetailServiceImpl();
            mapper = new AutoDataContractMapper();
            referenceDataServiceImpl = new ReferenceDataServiceImpl();
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

        public virtual bool Authenticate(string username, string password)
        {
            return loginServiceImpl.Authenticate(username, password);
        }
    }
}