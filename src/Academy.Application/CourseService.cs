using System.Runtime.Serialization;
using Academy.Application.Contract.Dtos;
using Academy.Application.Interfaces;
using Academy.Domain;
using Academy.Domain.Exceptions;
using Academy.Domain.Interfaces;

namespace Academy.Application;
public class CourseService : ICourseService
{
    private readonly ICourseRepository _courseRepository;

    public CourseService(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public int Create(CreateCourseDto command)
    {
        if (_courseRepository.GetBy(command.Name) != null)
            throw new DuplicatedCourseNameException();

        var course = new Course(command.Id, command.Name, command.IsOnline, command.Tuition, command.Instructor);
        _courseRepository.Create(course);
        return course.Id;
    }
    public void Edit(EditCourseDto command)
    {
        if (_courseRepository.GetBy(command.Id) == null)
            throw new CourseNotExistsException();
        var course = new Course(command.Id, command.Name, command.IsOnline, command.Tuition, command.Instructor);
        _courseRepository.Delete(command.Id);
        _courseRepository.Create(course);
    }

    public void Delete(int id)
    {
        _courseRepository.Delete(id);
    }


    public List<Course> GetAll()
    {
        return _courseRepository.GetAll();
    }
}
