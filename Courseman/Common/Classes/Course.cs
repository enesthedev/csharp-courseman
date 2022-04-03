﻿using Courseman.Common.Helpers;
using Courseman.Common.Interfaces;

namespace Courseman.Common.Classes
{
    public class Course : ICourse
    {
        public Course(string Name, int midtermRatio = 40, int finalRatio = 60)
        {
            this.Name = Name;

            // Opsiyonel elemanlar
            this.MidtermRatio = midtermRatio;
            this.FinalRatio = finalRatio;
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

        public int MidtermRatio { get; set; }
        public int FinalRatio { get; set; }

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
                    Debug.WriteLine("New Student:", new Dictionary<string, string> {
                        { "Name", student.Name },
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
                #if DEBUG
                    Debug.WriteLine("Remove Student:", new Dictionary<string, string> {
                        { "Name", student.Name },
                        { "Age", student.Age.ToString() },
                        { "IdentityNumber", student.IdentityNumber.ToString() }
                    });
                #endif
                Students.Remove(student);
            }
            return this;
        }

        public Course AttachAcademician(Academician academician)
        {
            if (this.Academician == null && academician != null) {
                this.Academician = academician;

                if (!academician.Courses.Contains(this))
                    academician.AddCourse(this);
            }
            return this;
        }
    }
}

