using System;
using System.Data;
using Kallivayalil.Domain;
using NHibernate;
using NHibernate.Criterion;

namespace Kallivayalil.DataAccess.Repositories
{
    public class LoginRepository : Repository
    {
        public static string openSymmetricKey = @"OPEN SYMMETRIC KEY encryptionkey  DECRYPTION BY PASSWORD = '{0}';";
        public static string GetPassword = @"select convert(varchar,decryptbykey(password)) from Logins where email ={0};";
        public static string GetDecryptedPassword = @"select convert(varchar,decryptbykey({0}));";
        public static string closeSymmetricKey = @"CLOSE SYMMETRIC KEY encryptionkey";

        public LoginRepository(ISession session) : base(session) {}
        public LoginRepository() : base(SessionFactory.OpenSession()) {}

        public Login Load(Email email)
        {
            var login = session.CreateCriteria<Login>().Add(Restrictions.Eq("Email", email)).UniqueResult<Login>();
            if (login != null && !string.IsNullOrEmpty(login.Password))
            {
                var transaction = session.BeginTransaction();
                OpenSymmetricKey(session.Connection, transaction);

                var dbCommand = session.Connection.CreateCommand();
                transaction.Enlist(dbCommand);
                dbCommand.CommandText = string.Format(GetPassword, email.Id);
                var result = dbCommand.ExecuteScalar();
                login.Password = result as string;
                CloseSymmetricKey(session.Connection, transaction);
//                transaction.Commit();
            }
            return login;
        }


        private static void OpenSymmetricKey(IDbConnection dbConnection, ITransaction txn)
        {
            using (var dbCommand = dbConnection.CreateCommand())
            {
                txn.Enlist(dbCommand);
                dbCommand.CommandText = String.Format(openSymmetricKey, "K@ll!v@y@l!l");
                dbCommand.ExecuteNonQuery();
            }
        }

        private static void CloseSymmetricKey(IDbConnection dbConnection, ITransaction txn)
        {
            using (var dbCommand = dbConnection.CreateCommand())
            {
                txn.Enlist(dbCommand);
                dbCommand.CommandText = closeSymmetricKey;
                dbCommand.ExecuteNonQuery();
            }
        }

        public bool Authenticate(Login userLogin, string password)
        {
            return string.Equals(userLogin.Email.Constituent.IsRegistered.ToString(),"R",StringComparison.InvariantCultureIgnoreCase) && userLogin.Password.Equals(password);
        }

        // todo :  manage transactions using windsor
        public Login Save(Login login)
        {
            using (var txn = session.BeginTransaction())
            {
                var savedLogin = SaveOrUpdate(login, txn);
                txn.Commit();
                return savedLogin;
            }
        }

        public Login Update(Login loginToUpdate)
        {
            using (var txn = session.BeginTransaction())
            {
                var savedLogin = SaveOrUpdate(loginToUpdate, txn);
                txn.Commit();
                return savedLogin;
            }
        }
    }
}