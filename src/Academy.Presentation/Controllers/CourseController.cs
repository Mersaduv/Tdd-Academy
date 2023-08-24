using System.Net;
using Academy.Application.Contract.Dtos;
using Academy.Application.Interfaces;
using Academy.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Academy.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CourseController : ControllerBase
{
    private readonly ICourseService _courseService;
    public CourseController(ICourseService courseService)
    {
        _courseService = courseService;
    }
    [HttpPost]
    public int CreateCourse(CreateCourseDto command)
    {
        return _courseService.Create(command);
    }

    [HttpDelete("{id}")]
    public void DeleteCourse(int id)
    {
        _courseService.Delete(id);
    }

    [HttpPut]
    public int EditCourse(EditCourseDto command)
    {
        return _courseService.Edit(command);
    }

    [HttpGet]
    public List<Course> GetCourses()
    {
        return _courseService.GetAll();
    }
}