using System;
namespace Courseman.Common.Models
{
	public class MStudent
	{
		public static string[] Fillable = {
			"Name",
			"Age",
			"IdentityNumber"
		};

		public static Dictionary<string, string> FriendlyProperties = new Dictionary<string, string> {
			{ "Name", "öğrenci isim" },
			{ "Age", "öğrenci yaş" },
			{ "IdentityNumber", "öğrenci kimlik no" }
		};
	}
}

