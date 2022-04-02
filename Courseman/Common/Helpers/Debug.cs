using System;
namespace Courseman.Common.Helpers
{
	public static class Debug
	{
		public static void WriteLine(string header, Dictionary<String, String> debugItems)
        {
			Console.WriteLine(header);

			foreach (KeyValuePair<string, string> kvp in debugItems) {
				Console.WriteLine("{0}:\t{1}", kvp.Key, kvp.Value);
            }
        }
	}
}

