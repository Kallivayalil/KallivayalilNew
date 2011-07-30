namespace Kallivayalil.Common.Extensions
{
    public static class StringExtensions
    {
        public static string Repeat(this string value, int number)
        {
            var finalValue = "";
            for (var i = 0; i < number; i++)
            {
                finalValue += value;
            }
            return finalValue;
        }
    }
}