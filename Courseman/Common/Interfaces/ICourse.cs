using Courseman.Common.Classes;

namespace Courseman.Common.Interfaces
{
	public interface ICourse
	{
		public string Name { get; set; }

		public Academician Academician { get; set; }
		public List<Student> Students { get; set; }

		public Course AddStudent(Student student);
		public Course RemoveStudent(Student student);

		public Course AttachAcademician(Academician academician);
	}
}

