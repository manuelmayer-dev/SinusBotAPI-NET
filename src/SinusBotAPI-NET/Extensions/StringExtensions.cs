namespace SinusBotAPI;

internal static class StringExtensions
{
    public static string AppendString(this string baseString, string append)
    {
        return $"{baseString}{append}";
    }
}