using Courseman.Common.Attributes;
using Courseman.Common.Interfaces;

namespace Courseman.Common.Entitys;

public class Academician : IAcademician, IWizardable
{
    private long _identityNumber;
    private string _name = null!;

    public Academician(string name = "İsimsiz Eğitmen", int age = 26, long identityNumber = 10000000000)
    {
        Name = name;
        Age = age;
        IdentityNumber = identityNumber;

        Courses = new List<Course>();
    }

    [Fillable(FriendlyName = "akademisyen isim")]
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
                throw new InvalidDataException($"{nameof(value)} cant bigger/lesser then length of 11");

            _identityNumber = value;
        }
    }

    [Fillable(FriendlyName = "akademisyen yaş")]
    public int Age { get; set; }

    public List<Course> Courses { get; set; }

    public Academician AddCourse(Course course)
    {
        if (Courses.Contains(course))
            return this;

        if (!course.Academician.Name.Equals(Name))
            course.AttachAcademician(this);

        return this;
    }
}