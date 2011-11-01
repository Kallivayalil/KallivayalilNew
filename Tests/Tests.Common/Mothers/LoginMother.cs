using Kallivayalil.Domain;

namespace Tests.Common.Mothers
{
    public static class LoginMother
    {
        public static Login User(Email email,string password,bool isAdmin)
        {
            return new Login { Email = email, Password = password, IsAdmin = isAdmin };
        }


    }
}