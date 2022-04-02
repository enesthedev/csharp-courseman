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

            this.Courses = new List<Course>();
            this.Grades = new List<Grade>();
		}

        private string _class { get; set; }
        public string Class {
            get { return _class; }
            set { _class = value; }
        }

        private List<Course> _courses { get; set; }
        public List<Course> Courses {
            get { return _courses; }
            set { _courses = value; }
        }

        private List<Grade> _grades { get; set; }
        public List<Grade> Grades {
            get { return _grades; }
            set { _grades = value;  }
        }

        private string _name { get; set; }
        public string Name {
            get { return _name; }
            set { _name = value; }
        }

        private int _age { get; set; }
        public int Age {
            get { return _age; }
            set { _age = value; }
        }

        private long _identityNumber { get; set; }
        public long IdentityNumber {
            get { return _identityNumber; }
            set { _identityNumber = value; }
        }
    }
}

