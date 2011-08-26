using System;
using System.Collections;
using System.Net.Mail;
using Kallivayalil.DataAccess.Repositories;
using Kallivayalil.Domain;
using Kallivayalil.Utility;

namespace Kallivayalil
{
    public class RegistrationServiceImpl
    {
        private readonly RegisterationRepository repository;
        private readonly Mail mail;


        public RegistrationServiceImpl(RegisterationRepository repository, Mail mail)
        {
            this.repository = repository;
            this.mail = mail;
        }


        public RegisterationConstituent CreateRegistrationConstituent(RegisterationConstituent registerationConstituent)
        {

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

    }
}