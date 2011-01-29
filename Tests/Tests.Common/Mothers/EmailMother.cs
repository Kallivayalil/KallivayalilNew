using Kallivayalil.Domain;
using Kallivayalil.Domain.ReferenceData;

namespace Tests.Common.Mothers
{
    public static class EmailMother
    {
        public static Email Official(Constituent constituent)
        {
            return new Email {Constituent = constituent, Address = "james.franklin@kallivayalil.com", Type = EmailTypeMother.Official()};
        }

    }
}