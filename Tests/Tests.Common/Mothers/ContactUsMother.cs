using Kallivayalil.Domain;

namespace Tests.Common.Mothers
{
    public static class ContactUsMother
    {
        public static ContactUs Test()
        {
            return new ContactUs { Name = "test", Email = "test", Comments = "test" };
        }

    }
}