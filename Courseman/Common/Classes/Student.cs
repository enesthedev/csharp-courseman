using System;
using Courseman.Common.Interfaces;
using Courseman.Common.Models;

namespace Courseman.Common.Classes
{
	public class Student: IStudent
	{
        public const int STUDENT_AGE = 21;

		public Student(string Name = "default", int Age = STUDENT_AGE, long IdentityNumber = 10000000000)
		{
            this.Name = Name;
            this.Age = Age;
            this.IdentityNumber = IdentityNumber;

            // Ön tanımlı elemanlar
            this.Fillable = MStudent.Fillable;
            this.FriendlyProperties = MStudent.FriendlyProperties;
		}

        public string[] Fillable { get; set; }

        public Dictionary<string, string> FriendlyProperties { get; set; }

        private string _name = null!;
        public string Name {
            get => _name;
            set {
                if (value == null)
                    throw new ArgumentNullException(nameof(value));

                _name = value;
            }
        }

        public int Age { get; set; }

        private long _identityNumber;
        public long IdentityNumber {
            get => _identityNumber;
            set {
                if (value >= 100000000000 || value <= 9999999999)
                    throw new InvalidDataException("IdentityNumber cant biger/less then length of 11");

                _identityNumber = value;
            }
        }

        public List<Course> Courses {
            get;
            set;
        } = new List<Course>();

        public Student AddCourse(Course course)
        {
            if (!Courses.Contains(course)) {
                Courses.Add(course);
            }

            if (!course.Students.Contains(this)) {
                course.AddStudent(this);
            }

            return this;
        }
    }
}

