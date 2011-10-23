using System;
using System.Collections.Generic;
using System.Linq;
using Kallivayalil.DataAccess.Repositories;
using Kallivayalil.Domain;
using Kallivayalil.Utility;

namespace Kallivayalil
{
    public class RegistrationServiceImpl
    {
        private readonly AddressServiceImpl addressServiceImpl;
        private readonly ConstituentRepository constituentRepository;
        private readonly EmailRepository emailRepository;
        private readonly EmailServiceImpl emailServiceImpl;
        private readonly LoginRepository loginRepository;
        private readonly Mail mail;
        private readonly PhoneServiceImpl phoneServiceImpl;
        private readonly RegisterationRepository repository;


        public RegistrationServiceImpl(RegisterationRepository repository, Mail mail,
                                       ConstituentRepository constituentRepository, LoginRepository loginRepository,
                                       EmailRepository emailRepository)
        {
            this.constituentRepository = constituentRepository;
            this.repository = repository;
            this.loginRepository = loginRepository;
            this.emailRepository = emailRepository;
            emailServiceImpl = new EmailServiceImpl(emailRepository);
            phoneServiceImpl = new PhoneServiceImpl(new PhoneRepository(), constituentRepository);
            addressServiceImpl = new AddressServiceImpl(new AddressRepository());
            this.mail = mail;
        }


        public RegisterationConstituent CreateRegistrationConstituent(RegisterationConstituent registerationConstituent)
        {
            registerationConstituent.Constituent.IsRegistered = 'A';
            RegisterationConstituent registrationConstituent = repository.Save(registerationConstituent);

            //need to get all admin mail ids and sent the mail to all admins
            mail.Send("kallivayalil.family@gmail.com", "RegistrationMail@Kallivayalil.com",
                      GetMail(registrationConstituent, Constants.AdminMailText));

            mail.Send(registrationConstituent.Email, "RegistrationMail@Kallivayalil.com",
                      GetMail(registrationConstituent, Constants.UserMailText));

            return registrationConstituent;
        }


        public string GetMail(RegisterationConstituent registrationConstituent, string mailText)
        {
            return string.Format(mailText) + Environment.NewLine +
                   string.Format(
                       "\n\nFirstName:{0}\nLastName:{1}\nFamily:{2}\nAddress:{3}\nEmail:{4}\nHomePhone:{5}\nRegisteration Date:{6}"
                       , registrationConstituent.Constituent.Name.FirstName,
                       registrationConstituent.Constituent.Name.LastName,
                       registrationConstituent.Constituent.BranchName
                       , registrationConstituent.Address.Description
                       , registrationConstituent.Email,
                       registrationConstituent.Phone.Number,
                       registrationConstituent.Constituent.CreatedDateTime);
        }

        public IList<Constituent> GetConstituentsForRegistration()
        {
            return constituentRepository.ConstituentsForApproval();
        }

        public void RegisterConstituent(int constituent, int constituentToRegister, bool isAdmin, bool updateAndRegister)
        {
            Constituent existingConstituent = constituent > 0 ? constituentRepository.Load(constituent):null;
            Constituent newConstituent = constituentRepository.Load(constituentToRegister);
            Constituent registeredConstituent = null;
            if (existingConstituent != null)
            {
                AddPhoneAddressAndEmailToExistingConstituent(newConstituent, existingConstituent);

                registeredConstituent = UpdateAsRegistered(existingConstituent);

                constituentRepository.Delete(newConstituent.Id);

            }
            else
            {
               registeredConstituent = UpdateAsRegistered(newConstituent);
            }

            UpdateAsAdmin(isAdmin, registeredConstituent.Id);

        }

        private void AddPhoneAddressAndEmailToExistingConstituent(Constituent newConstituent,
                                                                  Constituent existingConstituent)
        {
            Email email = emailServiceImpl.FindEmails(newConstituent.Id.ToString()).First();
            email.Constituent = existingConstituent;
            emailServiceImpl.UpdateEmail(email);

            Phone phone = phoneServiceImpl.FindPhones(newConstituent.Id.ToString()).First();
            phone.Constituent = existingConstituent;
            phoneServiceImpl.UpdatePhone(phone);

            Address address = addressServiceImpl.FindAddresses(newConstituent.Id.ToString()).First();
            address.Constituent = existingConstituent;
            addressServiceImpl.UpdateAddress(address);
        }

        private Constituent UpdateAsRegistered(Constituent existingConstituent)
        {
            existingConstituent.IsRegistered = 'R';
            return constituentRepository.Update(existingConstituent);
        }

        private void UpdateAsAdmin(bool isAdmin, int registeredConstituentId)
        {
            if (!isAdmin) return;
            Email primaryEmail = emailRepository.GetPrimary(registeredConstituentId);

            Login login = loginRepository.Load(primaryEmail);
            login.IsAdmin = true;
            loginRepository.Update(login);
        }

        #region Nested type: Constants

        public class Constants
        {
            public const string AdminMailText =
                @"New user has registered at kallivayalil.com. Please verify the below details and activate the account.";

            public const string UserMailText =
                @"Thank you for registering at kallivayalil.com. We will verify your information provided below and activate your account.You will be notified via Email once your account is activated.";

            public const string AESKey = "kalli";
        }

        #endregion
    }
}