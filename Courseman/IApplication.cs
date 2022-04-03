using System;
namespace Courseman
{
	public interface IApplication
	{
		List<dynamic> Courses { get; set; }
		List<dynamic> Students { get; set; }

		public static void Run();
	}
}

