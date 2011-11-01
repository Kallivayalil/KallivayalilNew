using Kallivayalil.Client;
using Kallivayalil.Domain;

namespace Tests.Integration.Mothers
{
    public static class LoginDataMother
    {
        public static LoginData User(Email email, string password, bool isAdmin)
        {
            EmailData emailData = GetEmailData(email);

            return new LoginData
                       {
                           Email = emailData,
                           Password = password,
                           IsAdmin = isAdmin
                       };
        }

        private static EmailData GetEmailData(Email email)
        {
            return email!=null ? new EmailData
                       {
                           Address = email.Address,
//                           Constituent = new LinkData {Id = email.Constituent.Id},
//                           IsPrimary = email.IsPrimary,
//                           Id = email.Id,
//                           Type = new EmailTypeData { Id = email.Type.Id,Description = email.Type.Description}
                       } : new EmailData(){};
        }
    }
}