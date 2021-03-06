using Courseman.Common.Interfaces;

namespace Courseman.Common.Helpers;

public class Input
{
    public static int ReadOptions(List<IWizardable> listOfClasses, bool minusOneEnabled = false)
    {
        try
        {
            var selectedOption = Convert.ToInt32(Console.ReadLine());

            if (minusOneEnabled && selectedOption == -1)
                return -1;

            dynamic selectedClass = listOfClasses.ElementAt(selectedOption);

            if (!(selectedClass != null))
                throw new ArgumentOutOfRangeException();

            Console.Clear();

            return selectedOption;
        }
        catch (Exception ex)
        {
            if (ex is ArgumentOutOfRangeException || ex is FormatException)
            {
                Console.WriteLine(
                    "Girdiğiniz değer mevcut değil.\nLütfen yeni bir değer girin:"
                );
                return ReadOptions(listOfClasses, minusOneEnabled);
            }

            throw;
        }
    }

    public static double ReadDouble(double min = double.MinValue, double max = double.MaxValue)
    {
        try
        {
            var value = Convert.ToDouble(
                Console.ReadLine()
            );

            if (value > max || min > value)
                throw new ArgumentOutOfRangeException();

            return value;
        }
        catch (Exception ex)
        {
            if (ex is ArgumentOutOfRangeException || ex is FormatException)
            {
                Application.WriteLine(
                    "Girdiğiniz değer mevcut değil.\nLütfen yeni bir değer girin:",
                    true
                );
                return ReadDouble(min, max);
            }

            throw;
        }
    }

    public static bool IsDouble(string value)
    {
        return value.IndexOf(".") != -1;
    }
}