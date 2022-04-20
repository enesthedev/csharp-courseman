using Courseman.Common.Attributes;
using Courseman.Common.Interfaces;

namespace Courseman.Common.Entitys;

public class Student : IStudent, IWizardable
{
    private long _identityNumber;
    private string _name = null!;

    public Student(string name = "İsimsiz Öğrenci", int age = 21, long identityNumber = 10000000000)
    {
        Name = name;
        Age = age;
        IdentityNumber = identityNumber;

        Courses = new List<Course>();
    }

    [Fillable(FriendlyName = "öğrenci isim")]
    public string Name
    {
        get => _name;
        set
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            _name = value;
        }
    }

    [Fillable(FriendlyName = "kimlik numarası")]
    public long IdentityNumber
    {
        get => _identityNumber;
        set
        {
            if (value >= 100000000000 || value <= 9999999999)
                throw new InvalidDataException("IdentityNumber cant biger/less then length of 11");

            _identityNumber = value;
        }
    }

    [Fillable(FriendlyName = "öğrenci yaş")]
    public int Age { get; set; }

    public List<Course> Courses { get; set; }

    public Student AddCourse(Course course)
    {
        if (!Courses.Contains(course))
            Courses.Add(course);

        if (!course.Students.Contains(this))
            course.AddStudent(this);

        return this;
    }
}