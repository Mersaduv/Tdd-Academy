using Academy.Domain;
using Academy.Domain.Interfaces;

namespace Academy.Infrastructure;

public class CourseRepository : ICourseRepository
{
    private readonly AcademyContext _context;

    public CourseRepository(AcademyContext context)
    {
        _context = context;
    }

    public void Create(Course course)
    {
        _context.Courses.Add(course);
        _context.SaveChanges();
    }

    public bool Delete(int id)
    {
        throw new NotImplementedException();
    }

    public List<Course> GetAll()
    {
        return _context.Courses.ToList();
    }

    public Course GetBy(int id)
    {
        throw new NotImplementedException();
    }

    public Course GetBy(string name)
    {
        throw new NotImplementedException();
    }



    //? UnitTest
    // public List<Course> Courses = new List<Course>
    //     {
    //         new Course(30, "Asp.net Core 5", true, 780, "Hossein")
    //     };

    // public void Create(Course course) => Courses.Add(course);

    // public List<Course> GetAll() => Courses;

    // public Course? GetBy(int id) => Courses.FirstOrDefault(c => c.Id == id);

    // public Course? GetBy(string name) => Courses.FirstOrDefault(c => c.Name == name);

    // public bool Delete(int id)
    // {
    //     var course = GetBy(id);
    //     Courses.Remove(course);
    //     return true;
    // }


}