using System.Collections.Generic;
using Kallivayalil.Domain;

namespace Kallivayalil.DataAccess.Repositories
{
    public interface IConstituentRepository
    {
        Constituent Save(Constituent constituent);
        Constituent Update(Constituent constituent);
        void Delete(int constituentId);
        Constituent Load(int constituentId);
        IList<Constituent> LoadAllConstituentsWithBirthdayToday();
        List<Constituent> SearchByConstituentName(string firstName, string lastName, string preferedName, bool matchAllCriteria);
        List<Constituent> SearchByConstituentBranch(string branchName);
        List<Constituent> SearchByConstituentHouseName(string houseName);
        List<Constituent> ConstituentsForApproval();
        void CascadeDelete(int constituentId);
    }
}