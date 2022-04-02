using Courseman.Common.Classes;

namespace Courseman.Common.Interfaces
{
	public interface ICourse
	{
		public string Name { get; set; }

		public Academician Academician { get; set; }
		public List<Student> Students { get; set; }

		Course addStudent(Student student);
		Course removeStudent(Student student);
	}
}

