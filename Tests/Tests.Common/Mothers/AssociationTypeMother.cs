using Kallivayalil.Domain.ReferenceData;

namespace Tests.Common.Mothers
{
    public static class AssociationTypeMother
    {
        public static AssociationType Spouse()
        {
            return new AssociationType() {Id = 1, Description = "Spouse"};
        }

        public static AssociationType Parent()
        {
            return new AssociationType { Id = 2, Description = "Parent" };
        }

        public static AssociationType Child()
        {
            return new AssociationType { Id = 2, Description = "Child" };
        }
    }
}