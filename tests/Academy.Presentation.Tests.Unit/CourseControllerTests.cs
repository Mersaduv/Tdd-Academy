using Academy.Application.Contract.Dtos;
using Academy.Application.Interfaces;
using Academy.Domain;
using Academy.Presentation.Controllers;
using FluentAssertions;
using NSubstitute;

namespace Academy.Presentation.Tests.Unit;

public class CourseControllerTests
{
    private readonly ICourseService _service;
    private readonly CourseController _controller;
    public CourseControllerTests()
    {
        _service = Substitute.For<ICourseService>();
        _controller = new CourseController(_service);
    }
    [Fact]
    public void Should_ReturnAllCourses()
    {

        _controller.GetCourses();

        _service.Received().GetAll();
    }

    [Fact]
    public void Should_ReturnTypeOfListCourse()
    {
        _service.GetAll().Returns(new List<Course>());

        var courses = _controller.GetCourses();

        courses.Should().BeOfType<List<Course>>();
    }

    [Fact]
    public void Should_CreateANewCourse()
    {
        var command = new CreateCourseDto
        {
            Name = "Tdd Bdd",
            Tuition = 1223
        };

        _controller.CreateCourse(command);

        _service.Received().Create(command);
    }

    [Fact]
    public void Should_EditExistingCourse()
    {
        var command = new EditCourseDto
        {
            Id = 1,
            Name = "Tdd Bdd",
            Tuition = 1222
        };

        _controller.EditCourse(command);

        _service.Received().Edit(command);
    }

    [Fact]
    public void Should_DeleteExistingCourse()
    {
        const int id = 1;

        _controller.DeleteCourse(id);

        _service.Received().Delete(id);
    }
}