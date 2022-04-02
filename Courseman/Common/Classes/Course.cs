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
        }

        private string _name = null!;
        public string Name
        {
            get => _name;
            set {
                if (value == null)
                    throw new ArgumentNullException(nameof(value));

                _name = value;
            }
        }

        private Academician _academician = null!;
        public Academician Academician
        {
            get => _academician;
            set {
                if (value == null)
                    throw new ArgumentNullException(nameof(value));

                _academician = value;
            }
        }

        public List<Student> Students {
            get;
            set;
        } = new List<Student>();

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
                Students.Add(student);
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

