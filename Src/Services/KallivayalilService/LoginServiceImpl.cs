using System;
using Kallivayalil.DataAccess.Repositories;
using Kallivayalil.Domain;
using Kallivayalil.Utility;

namespace Kallivayalil
{
    public class LoginServiceImpl : ILoginServiceImpl
    {
        private readonly ILoginRepository repository;
        private readonly IEmailRepository emailRepository;
        private readonly IMail mail;
        private readonly ConstituentRepository constituentRepository;

        public LoginServiceImpl(ILoginRepository loginRepository, IEmailRepository emailRepository, IMail mail)
        {
            repository = loginRepository;
            this.emailRepository = emailRepository;
            this.mail = mail;
            this.constituentRepository = constituentRepository;
        }


        public bool Authenticate(string username, string password)
        {
            var email = emailRepository.Load(username);
            if (email == null)
            {
                return false;
            }

            var login = repository.Load(email);
            return repository.Authenticate(login, password);
        }

        public void UpdateAsAdmin(bool isAdmin, int registeredConstituentId)
        {
            if (!isAdmin) return;
            Email primaryEmail = emailRepository.GetPrimary(registeredConstituentId);

            Login login = repository.Load(primaryEmail);
            login.IsAdmin = true;
            repository.Update(login);
        }

        public Login Update(Login login)
        {
            return repository.Update(login);
        }
        
        
        public Login Load(Email email)
        {
            return repository.Load(email);
        }

        public string ForgotPassword(string email)
        {
            var emailMatch = emailRepository.Load(email);
            if(emailMatch!=null && emailMatch.IsPrimary)
            {
                var login = repository.Load(emailMatch);
                if(login != null)
                { 
                    mail.Send(email, "Reply: Forgot Password Request",
                        string.Format("Dear Ma'am/Sir, \r\n Username:{0} \r\n Password:{1} \r\n Regards, \r\n Admin team.",email, login.Password));
                    return email;
                }
                
            }
            return null;
        }
    }
}