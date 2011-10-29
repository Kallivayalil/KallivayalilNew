using System;
using Kallivayalil.Client;
using Kallivayalil.DataAccess.Repositories;
using Kallivayalil.Domain;

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