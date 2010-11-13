using System;
using System.ServiceModel;
using System.ServiceModel.Activation;
using Kallivayalil.Client;
using Kallivayalil.Common;
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

        public KallivayalilService()
        {
            constituentServiceImpl = new ConstituentServiceImpl();
            nameServiceImpl = new ConstituentNameServiceImpl();
            addressServiceImpl = new AddressServiceImpl();
            phoneServiceImpl = new PhoneServiceImpl();
            emailServiceImpl = new EmailServiceImpl();
            mapper = new AutoDataContractMapper();
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
            Address address = new Address();
            mapper.Map(addressData, address);

            var savedAddress = addressServiceImpl.CreateAddress(address);
            AddressData savedAddressData = new AddressData();
            mapper.Map(savedAddress, savedAddressData);
            return savedAddressData;
        }

        public virtual AddressData UpdateAddress(string id, AddressData addressData)
        {
            Address address = new Address();
            mapper.Map(addressData, address);

            var savedAddress = addressServiceImpl.UpdateAddress(address);
            AddressData savedAddressData = new AddressData();
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

        public virtual PhoneData UpdatePhone(string constituentId, PhoneData phoneData)
        {
            var phone = new Phone();
            mapper.Map(phoneData,phone);

            var updatedPhone = phoneServiceImpl.UpdatePhone(phone);

            var updatedPhoneData = new PhoneData();

            mapper.Map(updatedPhone,updatedPhoneData);

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

            mapper.Map(phone,phoneData);

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

        public virtual EmailData UpdateEmail(string constituentId, EmailData emailData)
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
            mapper.MapList(emails, emailData, typeof(EmailData));
            return emailData;
        }
    }
}