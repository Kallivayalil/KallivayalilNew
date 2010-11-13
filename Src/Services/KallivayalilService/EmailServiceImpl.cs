using System;
using System.Collections.Generic;
using Kallivayalil.DataAccess.Repositories;
using Kallivayalil.Domain;

namespace Kallivayalil
{
    public class EmailServiceImpl
    {
        private readonly EmailRepository repository;

        public EmailServiceImpl()
        {
            repository = new EmailRepository();
        }

        public Email CreateEmail(Email email)
        {
            return repository.Save(email);
        }


        public Email UpdateEmail(Email email)
        {
            return repository.Update(email);
        }

        public Email FindEmail(string emailId)
        {
            return repository.Load(Convert.ToInt32(emailId));
        }

        public void DeleteEmail(string emailId)
        {
            repository.Delete(Convert.ToInt32(emailId));
        }

        public IList<Email> FindEmails(string constituentId)
        {
            return repository.LoadAll(Convert.ToInt32(constituentId));
        }
    }
}