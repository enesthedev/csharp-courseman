using System;
using System.Linq;
using Courseman.Common.Interfaces;

namespace Courseman.Common.Classes
{
    public class Course : ICourse
    {
        public Course(string Name)
        {
            this.Name = Name;
            this.Students = new List<Student>();
        }

        private string _name { get; set; }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private Academician _academician { get; set; }
        public Academician Academician
        {
            get { return _academician; }
            set { _academician = value; }
        }

        private List<Student> _students { get; set; }
        public List<Student> Students
        {
            get { return _students; }
            set { _students = value; }
        }

        public Course addStudent(Student student)
        {
            if (!Students.Contains(student)) {
                Students.Append(student);
            }
            return this;
        }

        public Course removeStudent(Student student)
        {
            if (Students.Contains(student)) {
                Students.Remove(student);
            }
            return this;
        }
    }
}

