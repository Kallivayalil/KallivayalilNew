using Kallivayalil.Domain.ReferenceData;

namespace Tests.Common.Mothers
{
    public static class EmailTypeMother
    {
        public static EmailType Official()
        {
            return new EmailType { Id = 1, Description = "Official" };
        }

        public static EmailType Personal()
        {
            return new EmailType { Id = 2, Description = "Personal" };
        }
    }
}