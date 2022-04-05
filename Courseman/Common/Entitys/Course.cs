using Courseman.Common.Interfaces;
using Courseman.Common.Enums;

namespace Courseman.Common.Entitys
{
    public class Course : ICourse
    {
        private string _name = null!;
        public string Name {
            get => _name;
            set {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException(nameof(value));

                _name = value;
            }
        }

        private Academician _academician = null!;
        public Academician Academician {
            get => _academician;
            set {
                if (value == null)
                    throw new ArgumentNullException(nameof(value));

                _academician = value;
            }
        }

        public int MidtermRatio { get; set; }
        public int FinalRatio { get; set; }

        public List<Student> Students { get; set; }

        public string[] Fillable = {
            "Name",
            "MidtermRatio",
            "FinalRatio",
        };

        public Dictionary<string, string> FriendlyPropertyNames = new Dictionary<string, string> {
            { "Name", "kursun isim" },
            { "MidtermRatio", "vize notu oranı" },
            { "FinalRatio", "final notu oranı" }
        };

        public Course(string name = "İsimsiz Kurs", int midtermRatio = (int)Ratios.Midterm, int finalRatio = (int)Ratios.Final)
        {
            this.Name = name;
            this.MidtermRatio = MidtermRatio;
            this.FinalRatio = FinalRatio;

            this.Students = new List<Student>();
            this.Academician = new Academician();
        }

        public Course AddStudent(Student student)
        {
            if (!Students.Contains(student))
                Students.Add(student);

            return this;
        }

        public Course RemoveStudent(Student student)
        {
            if (Students.Contains(student))
                Students.Remove(student);

            return this;
        }

        public Course AttachAcademician(Academician academician)
        {
            if (academician == null)
                return this;

            if (Academician.Name == academician.Name)
                return this;

            Academician = academician;

            if (!academician.Courses.Contains(this))
                academician.AddCourse(this);

            return this;
        }
    }
}