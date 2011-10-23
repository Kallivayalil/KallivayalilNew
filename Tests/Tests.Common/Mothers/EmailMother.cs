using Kallivayalil.Domain;

namespace Tests.Common.Mothers
{
    public static class EmailMother
    {
        public static Email Official(Constituent constituent)
        {
            return new Email {Constituent = constituent, Address = "james.franklin@kallivayalil.com", Type = EmailTypeMother.Official()};
        }

        public static Email Personal(Constituent constituent)
        {
            return new Email {Constituent = constituent, Address = "james.franklin@gmail.com", Type = EmailTypeMother.Personal()};
        }

        public static Email Official()
        {
            return new Email { Address = "james.franklin@kallivayalil.com", Type = EmailTypeMother.Official()};
        }
    }
}