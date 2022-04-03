namespace Courseman.Common.Helpers
{
	public class Input
	{
		public static int ReadOptions(List<dynamic> listOfClasses)
		{
			try {
				int selectedOption = Convert.ToInt32(Console.ReadLine());
				dynamic selectedClass = listOfClasses.ElementAt(selectedOption);

				if (!(selectedClass != null))
					throw new ArgumentOutOfRangeException();

				Console.Clear();

				return selectedOption;

			} catch (ArgumentOutOfRangeException) {

				Console.WriteLine("\n");
				Console.WriteLine("Girdiğiniz değer mevcut değil.\nLütfen yeni bir değer girin:");

				return ReadOptions(listOfClasses);
			}
		}
	}
}

