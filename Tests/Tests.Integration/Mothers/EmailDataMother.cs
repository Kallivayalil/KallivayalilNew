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
                           Type = 1,
                           Address = "james.franklin@kallivayalil.com",
                           Constituent = new LinkData {Id = constituent.Id},
                       };
        }

        public static EmailData Official(Email email)
        {
            return new EmailData()
            {
                Type = email.Type,
                Address = email.Address,
                Constituent = new LinkData{Id = email.Constituent.Id},
            };
        }
    }
}