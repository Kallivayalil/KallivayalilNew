using Kallivayalil.Domain;

namespace Tests.Common.Mothers
{
    public static class UploadMother
    {
        public static Upload Test(Constituent constituent)
        {
            return new Upload() { Name = "test", Description = "test", Constituent = constituent };
        }

    }
}