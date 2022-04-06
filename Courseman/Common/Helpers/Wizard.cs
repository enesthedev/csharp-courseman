using System;
using System.Reflection;

namespace Courseman.Common.Helpers
{
	public class Wizard
	{
		public static dynamic Mount(dynamic cls, dynamic dflcls, bool nullableString, params string[] messages)
        {
			string[] fillable = cls.Fillable;

			Dictionary<string, string> friendlyProperties = cls.FriendlyPropertyNames;
			PropertyInfo[] props = cls.GetType().GetProperties();

			Console.Clear();

			foreach (string message in messages)
				Console.WriteLine(message);

			Thread.Sleep(1500);

			foreach (PropertyInfo prop in props) {
				if (fillable.Contains(prop.Name)) {
					Application.WriteLine(
						"Lütfen {0} değerini giriniz (Varsayılan değer: {1}):",
						true,
						friendlyProperties.GetValueOrDefault(prop.Name, prop.Name),
						dflcls.GetType().GetProperty(prop.Name).GetValue(dflcls)
					);
					string? propValue = Console.ReadLine();

					if (propValue != null && propValue.Trim().Equals("-1"))
						return false;

					if (string.IsNullOrEmpty(propValue)) {
						if (!nullableString) {
							Application.WriteLine("Yanlış bir değer girdiniz, lütfen tekrar deneyin.", true);
							Thread.Sleep(1000);

							return Mount(cls, dflcls, nullableString, messages);
						}

						propValue = prop.GetValue(cls).ToString();
					}

					if (!Check(prop, propValue, friendlyProperties)) {
						Thread.Sleep(750);
						return Mount(
							cls,
							dflcls,
							nullableString,
							messages
						);
					}

					try {

						prop.SetValue(
							cls,
							ConvertToBaseType(propValue)
						);

					} catch(Exception) {

						Application.WriteLine(
							"Yanlış bir değer girdiniz, lütfen tekrar deneyin.",
							true
						);
						Thread.Sleep(1000);

						return Mount(cls, dflcls, nullableString, messages);
                    }
				}
			}

			return true;
		}

		private static bool Check(PropertyInfo prop, string propValue, Dictionary<string, string> friendlyProperties)
		{
			bool state = true;
			string propetyType = prop.PropertyType.ToString();

			if (propetyType.Equals("System.Int32")) {
				if (!Int32.TryParse(propValue, out int numberValue)) {
					Application.WriteLine(
						"{0} adlı değer sadece sayı içermelidir.",
						true,
						friendlyProperties.GetValueOrDefault(prop.Name, prop.Name)
					);
					Thread.Sleep(1500);

					state = false;
				}
			} else if (propetyType.Equals("System.Int64")) {
				if (!long.TryParse(propValue, out long numberValue)) {
					Application.WriteLine(
						"{0} adlı değer sadece sayı içermelidir.",
						true,
						friendlyProperties.GetValueOrDefault(prop.Name, prop.Name)
					);
					Thread.Sleep(1500);

					state = false;
				}
			}
			return state;
		}

		private static dynamic ConvertToBaseType(dynamic propValue)
		{
			if (Input.IsDouble(propValue) && double.TryParse(propValue, out double doubleValue))
				propValue = Convert.ToDouble(propValue);

			if (propValue.GetType().ToString().Equals("System.String") && Int32.TryParse(propValue, out int numberValue))
				propValue = Convert.ToInt32(propValue);

			if (propValue.GetType().ToString().Equals("System.String") && long.TryParse(propValue, out long longValue))
				propValue = Convert.ToInt64(propValue);

			return propValue;
		}
	}
}

