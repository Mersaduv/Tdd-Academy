using Academy.Domain;
using Academy.Domain.Interfaces;

namespace Academy.Infrastructure.Unit.Tests;

public class CourseRepository : ICourseRepository
{
    public List<Course> Courses = new List<Course>
        {
            new Course(30, "Asp.net Core 5", true, 780, "Hossein")
        };

    public void Create(Course course) => Courses.Add(course);

    public List<Course> GetAll() => Courses;

    public Course? GetBy(int id) => Courses.FirstOrDefault(c => c.Id == id);

    public Course? GetBy(string name) => Courses.FirstOrDefault(c => c.Name == name);
    
    public bool Delete(int id)
    {
        var course = GetBy(id);
        Courses.Remove(course);
        return true;
    }


}