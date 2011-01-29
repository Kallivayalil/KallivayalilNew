using System;
using System.Collections.Generic;
using Kallivayalil.Common;
using Kallivayalil.DataAccess.Repositories;
using Kallivayalil.Domain;
using Kallivayalil.Domain.ReferenceData;

namespace Kallivayalil
{
    public class EmailServiceImpl
    {
        private readonly EmailRepository repository;


        private void LoadEmailType(Email email)
        {
            if (Entity.IsNull(email.Type))
            {
                throw new BadRequestException("EmailType can not be null");
            }

            email.Type = repository.Load<EmailType>(email.Type.Id);
        }

        public EmailServiceImpl()
        {
            repository = new EmailRepository();
        }

        public Email CreateEmail(Email email)
        {
            LoadEmailType(email);
            return repository.Save(email);
        }


        public Email UpdateEmail(Email email)
        {
            LoadEmailType(email);
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