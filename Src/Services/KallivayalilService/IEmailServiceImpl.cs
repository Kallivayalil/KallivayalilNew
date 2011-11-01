using System.Collections.Generic;
using Kallivayalil.Domain;

namespace Kallivayalil
{
    public interface IEmailServiceImpl
    {
        Email CreateEmail(Email email);
        Email UpdateEmail(Email email);
        Email FindEmail(string emailId);
        Email FindEmailByAddress(string emailAddress);
        void DeleteEmail(string emailId);
        IList<Email> FindEmails(string constituentId);
        void SetConstituentAndUpdateEmail(string id, Constituent existingConstituent);
    }
}