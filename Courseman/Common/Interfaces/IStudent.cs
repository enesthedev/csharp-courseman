using System;
using Courseman.Common.Classes;

namespace Courseman.Common.Interfaces
{
	public interface IStudent : IPerson
	{
		public List<Course> Courses { get; set; }
		public List<Grade> Grades { get; set; }

		public Student AddCourse(Course course);
	}
}

