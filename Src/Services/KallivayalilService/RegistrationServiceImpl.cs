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
        private readonly IAddressServiceImpl addressServiceImpl;
        private readonly IConstituentRepository constituentRepository;
        private readonly IEmailServiceImpl emailServiceImpl;
        private readonly IMail mail;
        private readonly IPhoneServiceImpl phoneServiceImpl;
        private readonly IRegisterationRepository repository;
        private readonly ILoginServiceImpl loginServiceImpl;


        public RegistrationServiceImpl(IRegisterationRepository repository, IConstituentRepository constituentRepository, IMail mail, IEmailServiceImpl emailServiceImpl, IPhoneServiceImpl phoneServiceImpl, IAddressServiceImpl addressServiceImpl, ILoginServiceImpl loginServiceImpl)
        {
            this.constituentRepository = constituentRepository;
            this.repository = repository;
            this.emailServiceImpl = emailServiceImpl;
            this.phoneServiceImpl = phoneServiceImpl;
            this.addressServiceImpl = addressServiceImpl;
            this.loginServiceImpl = loginServiceImpl;
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

        public void RegisterConstituent(int constituent, int constituentToRegister, bool isAdmin, string adminEmail)
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

            loginServiceImpl.UpdateAsAdmin(isAdmin, registeredConstituent.Id);

            var email = emailServiceImpl.FindEmails(registeredConstituent.Id.ToString()).First();
            mail.Send(email.Address, "Kallivayalil Account Activated",Constants.UserMailTextAfterRegistration);

            mail.Send(adminEmail, "Kallivayalil Account Activated", string.Format(Constants.AdminMailTextAfterRegistration, email.Address));

        }

        private void AddPhoneAddressAndEmailToExistingConstituent(Constituent newConstituent,
                                                                  Constituent existingConstituent)
        {
            emailServiceImpl.SetConstituentAndUpdateEmail(newConstituent.Id.ToString(), existingConstituent);

            phoneServiceImpl.SetConstituentAndUpdatePhone(newConstituent.Id.ToString(), existingConstituent);

            addressServiceImpl.SetConstituentAndUpdateAddress(newConstituent.Id.ToString(), existingConstituent);
        }

        private Constituent UpdateAsRegistered(Constituent existingConstituent)
        {
            existingConstituent.IsRegistered = 'R';
            return constituentRepository.Update(existingConstituent);
        }

       

        #region Nested type: Constants

        public class Constants
        {
            public const string AdminMailText =
                @"New user has registered at kallivayalil.com. Please verify the below details and activate the account.";
            
            public const string AdminMailTextAfterRegistration =
                @"Account-{0} has been activated.";

            public const string UserMailText =
                @"Thank you for registering at kallivayalil.com. We will verify your information provided below and activate your account.You will be notified via Email once your account is activated.";
 
            public const string UserMailTextAfterRegistration = @"Your Account has been activated.";

            public const string AESKey = "kalli";
        }

        #endregion
    }
}