using System;
using Courseman.Common.Interfaces;

namespace Courseman.Common.Entitys
{
	public class Academician: IAcademician
	{
		private string _name = null!;
		public string Name {
			get => _name;
			set {
				if (value == null)
					throw new ArgumentNullException(nameof(value));

				_name = value;
            }
        }

		private long _identityNumber;
		public long IdentityNumber {
			get => _identityNumber;
			set {
				if (value >= 100000000000 || value <= 9999999999)
					throw new InvalidDataException($"{nameof(value)} cant bigger/lesser then length of 11");

				_identityNumber = value;
            }
        }

		public int Age { get; set; }

		public List<Course> Courses { get; set; }

		public Academician(string name = "İsimsiz Eğitmen", int age = 26, long identityNumber = 10000000000)
        {
			this.Name = name;
			this.Age = age;
			this.IdentityNumber = identityNumber;

			this.Courses = new List<Course>();
        }

		public Academician AddCourse(Course course)
        {
			if (Courses.Contains(course))
				return this;

			if (!course.Academician.Name.Equals(Name))
				course.AttachAcademician(this);

			return this;
        }

    }
}

