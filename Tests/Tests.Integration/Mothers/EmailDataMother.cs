using System;
using Kallivayalil.Client;
using Kallivayalil.Domain;

namespace Tests.Integration.Mothers
{
    public static class EmailDataMother
    {
        public static EmailData Official(Constituent constituent)
        {
            return new EmailData()
                       {
                           Type = new EmailTypeData{Id = 1,Description = "Official"},
                           Address = "james.franklin@kallivayalil.com",
                           Constituent = new LinkData {Id = constituent.Id},
                       };
        }

        public static EmailData Official(Email email)
        {
            return new EmailData()
            {
                Type = new EmailTypeData{Id = email.Type.Id,Description = email.Type.Description},
                Address = email.Address,
                Constituent = new LinkData{Id = email.Constituent.Id},
            };
        }
    }
}