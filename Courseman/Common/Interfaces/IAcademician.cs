using System;
using Courseman.Common.Classes;

namespace Courseman.Common.Interfaces
{
	public interface IAcademician: IPerson
	{
		public List<Course> Courses { get; set; }

		public Academician AddCourse(Course course);
	}
}

