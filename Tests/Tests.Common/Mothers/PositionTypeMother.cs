using Kallivayalil.Domain.ReferenceData;

namespace Tests.Common.Mothers
{
    public static class PositionTypeMother
    {
        public static PositionType President()
        {
            return new PositionType { Id = 1, Description = "President" };
        }

        public static PositionType Secretary()
        {
            return new PositionType { Id = 2, Description = "Secretary" };
        }
    }
}