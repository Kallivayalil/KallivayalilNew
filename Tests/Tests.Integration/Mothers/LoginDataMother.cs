using Kallivayalil.Client;
using Kallivayalil.Domain;

namespace Tests.Integration.Mothers
{
    public static class LoginDataMother
    {
        public static LoginData User(Email email, string password, bool isAdmin)
        {
            return new LoginData
                       {
                           Email = new EmailData
                                       {
                                           Address = email.Address,
                                           Constituent = new LinkData {Id = email.Constituent.Id},
                                           IsPrimary = email.IsPrimary,
                                           Id = email.Id,
                                           Type = new EmailTypeData { Id = email.Type.Id,Description = email.Type.Description}
                                       },
                           Password = password,
                           IsAdmin = isAdmin
                       };
        }

    }
}