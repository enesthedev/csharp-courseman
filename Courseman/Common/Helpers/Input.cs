namespace Courseman.Common.Helpers
{
	public class Input
	{
		public static int ReadOptions(List<dynamic> listOfClasses, bool minusOneEnabled = false)
		{
			try {
				int selectedOption = Convert.ToInt32(Console.ReadLine());

				if (minusOneEnabled && selectedOption == -1)
					return -1;

				dynamic selectedClass = listOfClasses.ElementAt(selectedOption);

				if (!(selectedClass != null))
					throw new ArgumentOutOfRangeException();

				Console.Clear();

				return selectedOption;

			} catch (Exception ex) {
				if (ex is ArgumentOutOfRangeException || ex is FormatException) {
					Console.WriteLine("Girdiğiniz değer mevcut değil.\nLütfen yeni bir değer girin:");
					return ReadOptions(listOfClasses, minusOneEnabled);
				}
				throw;
			}
		}
	}
}

