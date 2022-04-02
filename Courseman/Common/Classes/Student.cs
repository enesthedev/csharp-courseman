using System;
using Courseman.Common.Interfaces;

namespace Courseman.Common.Classes
{
	public class Student: IStudent
	{
		public Student(string Name, string Class, int Age, long IdentityNumber)
		{
            this.Name = Name;
            this.Class = Class;
            this.Age = Age;
            this.IdentityNumber = IdentityNumber;
		}

        private string _class = null!;
        public string Class {
            get => _class;
            set {
                if (value == null)
                    throw new ArgumentNullException(nameof(value));

                _class = value;
            }
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

        private long _identityNumber;
        public long IdentityNumber {
            get => _identityNumber;
            set {
                if (value >= 100000000000 || value <= 10000000000)
                    throw new InvalidDataException("IdentityNumber cant biger/less then length of 11");

                _identityNumber = value;
            }
        }

        public int Age { get; set; }

        public List<Course> Courses {
            get;
            set;
        } = new List<Course>();

        public List<Grade> Grades {
            get;
            set;
        } = new List<Grade>();

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

