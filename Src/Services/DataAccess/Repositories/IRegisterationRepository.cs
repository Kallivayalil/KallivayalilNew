using Kallivayalil.Domain;

namespace Kallivayalil.DataAccess.Repositories
{
    public interface IRegisterationRepository
    {
        RegisterationConstituent Save(RegisterationConstituent registerationConstituent);
    }
}