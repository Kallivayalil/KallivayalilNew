using Kallivayalil.DataAccess.Repositories;

namespace Kallivayalil
{
    public class LoginServiceImpl
    {
        private readonly LoginRepository repository;
        private readonly EmailRepository emailRepository;

        public LoginServiceImpl()
        {
            repository = new LoginRepository();
            emailRepository = new EmailRepository();
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
    }
}