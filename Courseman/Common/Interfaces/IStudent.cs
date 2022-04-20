using Courseman.Common.Entitys;

namespace Courseman.Common.Interfaces;

public interface IStudent : IPerson
{
    public List<Course> Courses { get; set; }
    public Student AddCourse(Course course);
}