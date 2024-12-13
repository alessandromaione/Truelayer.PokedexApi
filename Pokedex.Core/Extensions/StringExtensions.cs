namespace Pokedex.Core.Extensions
{
    public static class StringExtensions
    {
        public static bool EqualsIgnoreCase(this string? value, string toCompare)
        {
            if (value == null)
            {
                return false;
            }

            return value.Equals(toCompare, StringComparison.InvariantCultureIgnoreCase);
        }

        public static string? CleanUp(this string? value)
        {
            return value?
                 .Replace("\n", " ")
                 .Replace("\f", " ");
        }
    }
}