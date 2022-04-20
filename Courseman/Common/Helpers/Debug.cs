namespace Courseman.Common.Helpers;

public static class Debug
{
    public static void WriteLine(string header, Dictionary<string, string> debugItems)
    {
        Console.WriteLine(header);

        foreach (var kvp in debugItems) Console.WriteLine("{0}:\t{1}", kvp.Key, kvp.Value);
    }
}