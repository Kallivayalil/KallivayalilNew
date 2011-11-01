using Kallivayalil.Domain;

namespace Kallivayalil
{
    public interface ILoginServiceImpl
    {
        bool Authenticate(string username, string password);
        void UpdateAsAdmin(bool isAdmin, int registeredConstituentId);
        Login Update(Login login);
        Login Load(Email email);
    }
}