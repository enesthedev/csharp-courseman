using System;
using Courseman.Common.Interfaces;

namespace Courseman.Common.Entitys
{
	public class Student: IStudent
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
                    throw new InvalidDataException("IdentityNumber cant biger/less then length of 11");

                _identityNumber = value;
            }
        }


        public int Age { get; set; }

        public List<Course> Courses { get; set; }

        public string[] Fillable = {
            "Name",
            "Age",
            "IdentityNumber",
        };

        public Dictionary<string, string> FriendlyPropertyNames = new Dictionary<string, string> {
            { "Name", "öğrenci isim" },
            { "Age", "öğrenci yaş" },
            { "IdentityNumber", "kimik numarası" }
        };

        public Student(string Name = "İsimsiz Öğrenci", int Age = 21, long IdentityNumber = 10000000000)
        {
            this.Name = Name;
            this.Age = Age;
            this.IdentityNumber = IdentityNumber;

            this.Courses = new List<Course>();
        }

        public Student AddCourse(Course course)
        {
            if (course == null)
                return this;

            if (!Courses.Contains(course))
                Courses.Add(course);

            if (!course.Students.Contains(this))
                course.AddStudent(this);


            return this;
        }
    }
}

