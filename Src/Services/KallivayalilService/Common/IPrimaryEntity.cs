namespace Kallivayalil.Common
{
    public interface IPrimaryEntity : IEntity
    {
        bool IsPrimary { get; set; }
    }
}