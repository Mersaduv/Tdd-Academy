
using Academy.Application.Contract.Dtos;
using Academy.Domain;
using Academy.Domain.Exceptions;
using Academy.Domain.Interfaces;
using Academy.Domain.Unit.Tests.Builder;
using FluentAssertions;
using NSubstitute;
using Tynamix.ObjectFiller;

namespace Academy.Application.Tests.Unit;

public class CourseServiceTests
{
    private readonly CourseTestBuilder _courseTestBuilder;
    private readonly CourseService _courseService;
    private readonly ICourseRepository _courseRepository;

    // constructor
    public CourseServiceTests()
    {
        _courseTestBuilder = new CourseTestBuilder();
        _courseRepository = Substitute.For<ICourseRepository>();
        _courseService = new CourseService(_courseRepository);
    }

    private static CreateCourseDto SomeCreateCourse()
    {
        var filler = new Filler<CreateCourseDto>();
        filler.Setup().OnProperty(c => c.Tuition).Use(700);

        return filler.Create();
    }

    [Fact]
    public void Should_CreateANewCourse()
    {
        var command = SomeCreateCourse();

        _courseService.Create(command);

        _courseRepository.ReceivedWithAnyArgs().Create(default);
    }

    [Fact]
    public void Should_CreateNewCourseAndReturnId()
    {
        var command = SomeCreateCourse();

        var actual = _courseService.Create(command);

        actual.Should().Be(command.Id);
    }

    [Fact]
    public void Should_ThrowException_WhenAddingCourseIsDuplicated()
    {
        var command = SomeCreateCourse();
        var course = _courseTestBuilder.Build();
        _courseRepository.GetBy(Arg.Any<string>()).Returns(course);

        Action actual = () => _courseService.Create(command);


        actual.Should().ThrowExactly<DuplicatedCourseNameException>();

    }

    [Fact]
    public void Should_UpdateCourse()
    {
        var command = SomeEditCourse();
        var course = _courseTestBuilder.Build();
        _courseRepository.GetBy(command.Id).Returns(course);

        _courseService.Edit(command);

        Received.InOrder(() =>
        {
            _courseRepository.Delete(command.Id);
            _courseRepository.Create(Arg.Any<Course>());
        });
    }

    private static EditCourseDto SomeEditCourse()
    {
        return new EditCourseDto
        {
            Id = 1,
            Name = "Tdd",
            Tuition = 200,
            Instructor = "mersad",
            IsOnline = true
        };
    }

    [Fact]
    public void Should_ThrowException_WhenUpdatingCourseNotExists()
    {
        var command = SomeEditCourse();
        _courseRepository.GetBy(command.Id).Returns((Course)null);


        Action action = () => _courseService.Edit(command);


        action.Should().ThrowExactly<CourseNotExistsException>();
    }

    [Fact]
    public void Should_DeleteCourse()
    {
        const int id = 1;

        _courseService.Delete(id);

        _courseRepository.Received().Delete(id);
    }

    [Fact]
    public void Should_GetListOfCourse()
    {
        _courseRepository.GetAll().Returns(new List<Course>());

        var courses = _courseService.GetAll();

        courses.Should().BeOfType<List<Course>>();
        _courseRepository.Received().GetAll();
    }

}
