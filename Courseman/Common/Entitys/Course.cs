using Courseman.Common.Attributes;
using Courseman.Common.Enums;
using Courseman.Common.Interfaces;

namespace Courseman.Common.Entitys;

public class Course : ICourse, IWizardable
{
    private Academician _academician = null!;
    private string _name = null!;

    public Course(string name = "İsimsiz Kurs", double midtermRatio = (double)Ratios.Midterm / 100,
        double finalRatio = (double)Ratios.Final / 100)
    {
        Name = name;
        MidtermRatio = midtermRatio;
        FinalRatio = finalRatio;

        Students = new List<Student>();
        Academician = new Academician();
    }

    [Fillable(FriendlyName = "kursun isim")]
    public string Name
    {
        get => _name;
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value));

            _name = value;
        }
    }

    public Academician Academician
    {
        get => _academician;
        set
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            _academician = value;
        }
    }

    [Fillable(FriendlyName = "vize notu oranı")]
    public double MidtermRatio { get; set; }

    [Fillable(FriendlyName = "final notu oranı")]
    public double FinalRatio { get; set; }

    public List<Student> Students { get; set; }

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
        if (Academician.Name == academician.Name)
            return this;

        Academician = academician;

        if (!academician.Courses.Contains(this))
            academician.AddCourse(this);

        return this;
    }

    public double CalculatePoint(double point, int type)
    {
        var ratio = 0.0;
        switch (type)
        {
            case 0:
                ratio = MidtermRatio;
                break;
            case 1:
                ratio = FinalRatio;
                break;
        }

        return point * (ratio > 1 ? ratio / 100 : ratio);
    }
}