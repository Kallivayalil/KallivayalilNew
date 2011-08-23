using Kallivayalil.Domain;
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
                if(savedConstituent.Id > 0)
                {
                    savedRegisterationConstituent.Constituent = savedConstituent;
                    var savedAddress = GetSavedAddress(registerationConstituent, txn, savedConstituent);
                  
                    if (savedAddress.Id > 0)
                    {
                        savedRegisterationConstituent.Address = savedAddress;
                        var savedEmail = GetSavedEmail(registerationConstituent, txn, savedConstituent);
                        if (savedEmail != null && savedEmail.Id > 0)
                        {
                            savedRegisterationConstituent.Email = savedEmail;
                            var savedPhone = GetSavedPhone(registerationConstituent, txn, savedConstituent);
                            if (savedPhone != null && savedPhone.Id > 0)
                                savedRegisterationConstituent.Phone = savedPhone;
                        }
                    }
                   
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
            registerationConstituent.Email.Constituent = savedConstituent;
            return SaveOrUpdate(registerationConstituent.Email,txn);
        }
    }
}