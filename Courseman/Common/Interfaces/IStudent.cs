using System;
namespace Courseman.Common.Interfaces
{
	public interface IStudent : IPerson
	{
		public string Class { get; set; }

		public Array Courses { get; set; }
		public Array Grades { get; set; }
	}
}

