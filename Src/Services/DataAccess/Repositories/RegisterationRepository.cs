using Kallivayalil.Domain;
using Kallivayalil.Domain.ReferenceData;
using NHibernate;

namespace Kallivayalil.DataAccess.Repositories
{
    public class RegisterationRepository : Repository
    {
        public RegisterationRepository(ISession session) : base(session)
        {
        }

        public RegisterationRepository() : this(SessionFactory.OpenSession()) {}

        public RegisterationConstituent Save(RegisterationConstituent registerationConstituent)
        {
            var savedRegisterationConstituent = new RegisterationConstituent();
            using (var txn = session.BeginTransaction())
            {
                var savedConstituent = SaveOrUpdate(registerationConstituent.Constituent, txn);
                if (savedConstituent.Id > 0)
                {
                    savedRegisterationConstituent.Constituent = savedConstituent;
                    savedRegisterationConstituent.Address = GetSavedAddress(registerationConstituent, txn, savedConstituent);
                    savedRegisterationConstituent.Email = GetSavedEmail(registerationConstituent, txn, savedConstituent).Address;
                    savedRegisterationConstituent.Phone = GetSavedPhone(registerationConstituent, txn, savedConstituent);
                }
                txn.Commit();
                return savedRegisterationConstituent;
            }
        }

        private Address GetSavedAddress(RegisterationConstituent registerationConstituent, ITransaction txn, Constituent savedConstituent)
        {
            registerationConstituent.Address.Constituent = savedConstituent;
            return SaveOrUpdate(registerationConstituent.Address,txn);
        }

        private Phone GetSavedPhone(RegisterationConstituent registerationConstituent, ITransaction txn, Constituent savedConstituent)
        {
            registerationConstituent.Phone.Constituent = savedConstituent;
            return SaveOrUpdate(registerationConstituent.Phone,txn);
        } 
        
        private Email GetSavedEmail(RegisterationConstituent registerationConstituent, ITransaction txn, Constituent savedConstituent)
        {
            var email = new Email()
                            {
                                Constituent =savedConstituent,
                                Address = registerationConstituent.Email,
                                Type = new EmailType() { Id = 1}
                            };
            return SaveOrUpdate(email,txn);
        }
    }
}