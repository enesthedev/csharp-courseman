using System;
namespace Courseman.Common.Models
{
	public class MCourse
	{
		public static string[] Fillable = {
			"Name",
			"MidtermRatio",
			"FinalRatio"
		};

		public static Dictionary<string, string> FriendlyProperties = new Dictionary<string, string> {
			{ "Name", "kursun isim" },
			{ "MidtermRatio", "vize notu oranı" },
			{ "FinalRatio", "final notu oranı" }
		};
	}
}

