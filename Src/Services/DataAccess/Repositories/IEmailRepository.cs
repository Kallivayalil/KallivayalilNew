using System.Collections.Generic;
using Kallivayalil.Domain;

namespace Kallivayalil.DataAccess.Repositories
{
    public interface IEmailRepository
    {
        Email Load(string address);
        List<Constituent> SearchByEmail(string email);
        Email GetPrimary(int constituentId);
    }
}