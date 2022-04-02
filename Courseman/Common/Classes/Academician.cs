using System;
using Courseman.Common.Interfaces;

namespace Courseman.Common.Classes
{
	public class Academician: IAcademician
	{
		public Academician(string Name)
		{
			this.Name = Name;
		}

		private string _name = null!;
		public string Name {
			get => _name;
			set {
				if (value == null)
					throw new ArgumentNullException(nameof(value));

				_name = value;
            }
        }

		private long _identityNumber = 00000000000;
		public long IdentityNumber {
			get => _identityNumber;
			set {
				if (value >= 100000000000 || value <= 10000000000)
					throw new InvalidDataException($"{nameof(value)} cant bigger/lesser then length of 11");

				_identityNumber = value;
            }
        }

		public int Age { get; set; } = 0;

		public List<Course> Courses { get; set; } = new List<Course>();

		public Academician AddCourse(Course course)
        {
			if (!Courses.Contains(course)) {
				Courses.Add(course);

				if(course.Academician == null)
					course.AttachAcademician(this);
			}
            
			return this;
        }

    }
}

