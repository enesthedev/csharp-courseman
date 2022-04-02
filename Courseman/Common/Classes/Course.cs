using System;
using System.Linq;
using Courseman.Common.Helpers;
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

        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private Academician _academician;
        public Academician Academician
        {
            get { return _academician; }
            set { _academician = value; }
        }

        private List<Student> _students;
        public List<Student> Students
        {
            get { return _students; }
            set { _students = value; }
        }

        public Course AddStudent(Student student)
        {
            if (!Students.Contains(student)) {
                #if DEBUG
                    Debug.WriteLine("Course.cs", new Dictionary<string, string> {
                        { "Name", student.Name },
                        { "Class", student.Class },
                        { "Age", student.Age.ToString() },
                        { "IdentityNumber", student.IdentityNumber.ToString() }
                    });
                #endif
                Students.Append(student);
            }
            return this;
        }

        public Course RemoveStudent(Student student)
        {
            if (Students.Contains(student)) {
                Students.Remove(student);
            }
            return this;
        }
    }
}

