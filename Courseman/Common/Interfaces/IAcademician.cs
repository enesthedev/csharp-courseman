using System;
using Courseman.Common.Entitys;

namespace Courseman.Common.Interfaces
{
	public interface IAcademician: IPerson
	{
		public List<Course> Courses { get; set; }

		public Academician AddCourse(Course course);
	}
}

