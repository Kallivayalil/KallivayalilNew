using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using Kallivayalil.DataAccess.Repositories;
using Kallivayalil.Domain;
using Kallivayalil.Utility;
using System.Linq;

namespace Kallivayalil
{
    public class RegistrationServiceImpl
    {
        private readonly RegisterationRepository repository;
        private readonly Mail mail;
        private readonly ConstituentRepository constituentRepository;
        private readonly LoginRepository loginRepository;
        private readonly EmailRepository emailRepository;


        public RegistrationServiceImpl(RegisterationRepository repository, Mail mail, ConstituentRepository constituentRepository, LoginRepository loginRepository, EmailRepository emailRepository)
        {
            this.constituentRepository = constituentRepository;
            this.repository = repository;
            this.loginRepository = loginRepository;
            this.emailRepository = emailRepository;
            this.mail = mail;
        }


        public RegisterationConstituent CreateRegistrationConstituent(RegisterationConstituent registerationConstituent)
        {

            registerationConstituent.Constituent.IsRegistered = 'A';
            var registrationConstituent = repository.Save(registerationConstituent);

            //need to get all admin mail ids and sent the mail to all admins
            mail.Send("kallivayalil.family@gmail.com", "RegistrationMail@Kallivayalil.com",GetMail(registrationConstituent, Constants.AdminMailText));

            mail.Send(registrationConstituent.Email, "RegistrationMail@Kallivayalil.com",GetMail(registrationConstituent, Constants.UserMailText));

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

        public class Constants
        {
            public const string AdminMailText = @"New user has registered at kallivayalil.com. Please verify the below details and activate the account.";
            public const string UserMailText = @"Thank you for registering at kallivayalil.com. We will verify your information provided below and activate your account.You will be notified via Email once your account is activated.";
            public const string AESKey = "kalli";
        }

        public IList<Constituent> GetConstituentsForRegistration()
        {
            return constituentRepository.ConstituentsForApproval();
        }

        public void RegisterConstituent(int constituent, int constituentToRegister, bool isAdmin, bool updateAndRegister)
        {
            var existingConstituent = constituentRepository.Load(constituent);
            var newConstituent = constituentRepository.Load(constituentToRegister);

            existingConstituent.IsRegistered = 'R';
            var registeredConstituent = constituentRepository.Update(existingConstituent);

            UpdateAsAdmin(isAdmin, registeredConstituent.Id);
            
            constituentRepository.CascadeDelete(newConstituent.Id);
        }

        private void UpdateAsAdmin(bool isAdmin, int registeredConstituentId)
        {
            var primaryEmail = emailRepository.GetPrimary(registeredConstituentId);

            var login = loginRepository.Load(primaryEmail);
            login.IsAdmin = isAdmin;
            loginRepository.Update(login);
        }
    }
}