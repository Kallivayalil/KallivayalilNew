using Kallivayalil.Client;
using Kallivayalil.Domain;

namespace Tests.Integration.Mothers
{
    public static class UploadDataMother
    {
        public static UploadData Test(Constituent constituent)
        {
            return new UploadData() { Constituent = new ConstituentData() { Id = constituent.Id }, Name = "2004", Description = "2008" };
        }

        public static UploadData Test(Upload upload)
        {
            return new UploadData() { Constituent = new ConstituentData() { Id = upload.Id }, Name = upload.Name, Description = upload.Description };
        }

    
    }
}