using Kallivayalil.Domain;

namespace Kallivayalil.DataAccess.Repositories
{
    public interface ILoginRepository
    {
        Login Load(Email email);
        bool Authenticate(Login userLogin, string password);
        Login Save(Login login);
        Login Update(Login loginToUpdate);
    }
}