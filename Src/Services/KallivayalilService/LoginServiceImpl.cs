using Kallivayalil.DataAccess.Repositories;
using Kallivayalil.Domain;

namespace Kallivayalil
{
    public class LoginServiceImpl : ILoginServiceImpl
    {
        private readonly LoginRepository repository;
        private readonly EmailRepository emailRepository;

        public LoginServiceImpl(LoginRepository loginRepository, EmailRepository emailRepository)
        {
            repository = loginRepository;
            this.emailRepository = emailRepository;
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
    }
}