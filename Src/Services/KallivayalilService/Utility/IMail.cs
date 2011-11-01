namespace Kallivayalil.Utility
{
    public interface IMail
    {
        void Send(string to, string subject, string mailBody);
    }
}