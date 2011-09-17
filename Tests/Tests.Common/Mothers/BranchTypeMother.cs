using Kallivayalil.Domain.ReferenceData;

namespace Tests.Common.Mothers
{
    public static class BranchTypeMother
    {
        public static BranchType Kallivayalil()
        {
            return new BranchType() {Id = 1, Description = "Kallivayalil"};
        }

        public static BranchType Anavalaril()
        {
            return new BranchType() {Id = 2, Description = "Anavalaril"};
        }

        public static BranchType Kodooparambil()
        {
            return new BranchType() {Id = 2, Description = "Kodooparambil"};
        }
    }
}