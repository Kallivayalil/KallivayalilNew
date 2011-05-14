using System;
using System.Data;
using System.Text;
using Kallivayalil.Domain;
using NHibernate;

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
            var login = Load<Login>(email.Id);
            if(login!=null && !string.IsNullOrEmpty(login.Password))
            {
                var transaction = session.BeginTransaction();
                OpenSymmetricKey(session.Connection,transaction);

                var dbCommand = session.Connection.CreateCommand();
                transaction.Enlist(dbCommand);
                dbCommand.CommandText = string.Format(GetPassword, login.Id);
                var result = dbCommand.ExecuteScalar();
                login.Password = result as string ;
                CloseSymmetricKey(session.Connection,transaction);
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
            return userLogin.Password.Equals(password);
        }
    }
}