using System.Reflection;
using Courseman.Common.Attributes;
using Courseman.Common.Interfaces;

namespace Courseman.Common.Helpers;

public class Wizard
{
    public static dynamic Mount(IWizardable cls, IWizardable dflcls, bool nullableString, params string[] messages)
    {
        var props = cls.GetType().GetProperties();

        Console.Clear();

        foreach (var message in messages)
            Console.WriteLine(message);

        Thread.Sleep(1500);

        foreach (var prop in props)
        {
            var isDef = Attribute.IsDefined(prop, typeof(FillableAttribute));
            if (isDef)
            {
                var fillableAttribute =
                    (FillableAttribute)Attribute.GetCustomAttribute(prop, typeof(FillableAttribute));
                Application.WriteLine(
                    "Lütfen {0} değerini giriniz (Varsayılan değer: {1}):",
                    true,
                    fillableAttribute.FriendlyName,
                    dflcls.GetType().GetProperty(prop.Name).GetValue(dflcls)
                );
                var propValue = Console.ReadLine();

                if (propValue != null && propValue.Trim().Equals("-1"))
                    return false;

                if (string.IsNullOrEmpty(propValue))
                {
                    if (!nullableString)
                    {
                        Application.WriteLine("Yanlış bir değer girdiniz, lütfen tekrar deneyin.", true);
                        Thread.Sleep(1000);

                        return Mount(cls, dflcls, nullableString, messages);
                    }

                    propValue = prop.GetValue(cls).ToString();
                }

                if (!Check(prop, propValue, fillableAttribute.FriendlyName))
                {
                    Thread.Sleep(750);
                    return Mount(
                        cls,
                        dflcls,
                        nullableString,
                        messages
                    );
                }

                try
                {
                    prop.SetValue(
                        cls,
                        ConvertToBaseType(propValue)
                    );
                }
                catch (Exception)
                {
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

    private static bool Check(PropertyInfo prop, string propValue, string friendlyName)
    {
        var state = true;
        var propetyType = prop.PropertyType.ToString();

        if (propetyType.Equals("System.Int32"))
        {
            if (!int.TryParse(propValue, out var numberValue))
            {
                Application.WriteLine(
                    "{0} adlı değer sadece sayı içermelidir.",
                    true,
                    friendlyName
                );
                Thread.Sleep(1500);

                state = false;
            }
        }
        else if (propetyType.Equals("System.Int64"))
        {
            if (!long.TryParse(propValue, out var numberValue))
            {
                Application.WriteLine(
                    "{0} adlı değer sadece sayı içermelidir.",
                    true,
                    friendlyName
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

        if (propValue.GetType().ToString().Equals("System.String") && int.TryParse(propValue, out int numberValue))
            propValue = Convert.ToInt32(propValue);

        if (propValue.GetType().ToString().Equals("System.String") && long.TryParse(propValue, out long longValue))
            propValue = Convert.ToInt64(propValue);

        return propValue;
    }
}