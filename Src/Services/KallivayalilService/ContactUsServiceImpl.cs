using Kallivayalil.DataAccess.Repositories;
using Kallivayalil.Domain;

namespace Kallivayalil
{
    public class ContactUsServiceImpl 
    {
        private readonly ContactUsRepository repository;

        public ContactUsServiceImpl(ContactUsRepository contactUsRepository)
        {
            repository = contactUsRepository;
        }

        public ContactUs CreateContactUs(ContactUs contactUs)
        {
            return repository.Save(contactUs);
        }


    }
}