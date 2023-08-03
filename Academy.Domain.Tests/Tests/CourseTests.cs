using Academy.Domain.Exceptions;
using Academy.Domain.Tests.Builder;
using FluentAssertions;

namespace Academy.Domain.Tests;

public class CourseTests
{
    private readonly CourseTestBuilder _courseBuilder;

    public CourseTests() => _courseBuilder = new CourseTestBuilder();

    [Fact]
    public void Constructor_ShouldConstructCourseProperly()
    {
        // arrange
        //var guid = IdentifierFixture.Id;
        const int id = 1;
        const string name = "tdd & bdd";
        const bool isOnline = true;
        const double tuition = 600;
        const string instructor = "hossein";
        var course = _courseBuilder.Build();


        //assert
        course.Id.Should().Be(id);
        course.Name.Should().Be(name);
        course.IsOnline.Should().Be(isOnline);
        course.Tuition.Should().Be(tuition);
        course.Instructor.Should().Be(instructor);
    }

    [Fact]
    public void Constructor_ShouldThorwException_WhenNameIsNotProvided()
    {
        Action action = () => _courseBuilder.WithName("").Build();
        action.Should().ThrowExactly<CourseNameIsInvalidException>();
    }

    [Fact]
    public void Constructor_ShouldThrowException_WhenTuitionIsNotProvided()
    {

        Action action = () => _courseBuilder.WithTuition(0).Build();
        action.Should().ThrowExactly<CourseTuitionIsInvalidExecution>();
    }
}
