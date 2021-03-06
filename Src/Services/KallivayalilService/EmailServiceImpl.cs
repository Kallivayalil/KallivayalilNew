using System;
using System.Collections.Generic;
using System.Linq;
using Kallivayalil.Common;
using Kallivayalil.DataAccess.Repositories;
using Kallivayalil.Domain;
using Kallivayalil.Domain.ReferenceData;

namespace Kallivayalil
{
    public class EmailServiceImpl : BaseServiceImpl<Email>, IEmailServiceImpl
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

        public EmailServiceImpl(EmailRepository emailRepository) : base(emailRepository)
        {
            repository = emailRepository;
        }

        public Email CreateEmail(Email email)
        {
            LoadEmailType(email);
            OneEntityShouldBePrimary(email);
            return repository.Save(email);
        }


        public Email UpdateEmail(Email email)
        {
            LoadEmailType(email);
            OneEntityShouldBePrimary(email);
            return repository.Update(email);
        }

        public Email FindEmail(string emailId)
        {
            return repository.Load(Convert.ToInt32(emailId));
        }

        public Email FindEmailByAddress(string emailAddress)
        {
            return repository.Load(emailAddress);
        }

        public void DeleteEmail(string emailId)
        {
            repository.Delete(Convert.ToInt32(emailId));
        }

        public virtual IList<Email> FindEmails(string constituentId)
        {
            return repository.LoadAll(Convert.ToInt32(constituentId));
        }

        public void SetConstituentAndUpdateEmail(string id, Constituent existingConstituent)
        {
            var email = FindEmails(id).First();
            email.Constituent = existingConstituent;
            UpdateEmail(email);
        }
    }
}