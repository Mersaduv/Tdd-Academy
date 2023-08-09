using Academy.Application.Contract.Dtos;
using Academy.Domain;


namespace Academy.Application.Interfaces;

public interface ICourseService
{
    int Create(CreateCourseDto command);
    void Edit(EditCourseDto command);
    // void Delete(int id);
    // List<Course> GetAll();
}