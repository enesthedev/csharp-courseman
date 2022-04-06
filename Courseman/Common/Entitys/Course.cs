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

        public double MidtermRatio { get; set; }
        public double FinalRatio { get; set; }

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

        public Course(string name = "İsimsiz Kurs", double midtermRatio = (double)Ratios.Midterm/100, double finalRatio = (double)Ratios.Final/100)
        {
            this.Name = name;
            this.MidtermRatio = midtermRatio;
            this.FinalRatio = finalRatio;

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

        public double CalculatePoint(double point, int type)
        {
            double ratio = 0.0;
            switch(type) {
                case 0:
                    ratio = MidtermRatio;
                    break;
                case 1:
                    ratio = FinalRatio;
                    break;
            }

            return (double)(point * (ratio > 1 ? (ratio / 100) : ratio));
        }
    }
}