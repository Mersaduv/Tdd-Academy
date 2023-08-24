using System.Transactions;
using Academy.Domain;
using Academy.Domain.Unit.Tests.Builder;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace Academy.Infrastructure.Tests.Integration;

public class CourseRepositoryTests : IClassFixture<RealDatabaseFixture>
{
    private readonly CourseRepository _repository;
    private readonly CourseTestBuilder _courseBuilder;
    public CourseRepositoryTests(RealDatabaseFixture databaseFixture)
    {
        _courseBuilder = new CourseTestBuilder();
        _repository = new CourseRepository(databaseFixture.Context);
    }


    [Fact]
    public void Should_ReturnAllCourses()
    {
        var course = _repository.GetAll();

        course.Should().HaveCountGreaterThanOrEqualTo(3);
    }

    [Fact]
    public void Should_CreateCourse()
    {
        var course = _courseBuilder.Build();

        _repository.Create(course);

        var courses = _repository.GetAll();
        courses.Should().Contain(course);
    }

    [Fact]
    public void Should_ReturnIdOfCreatedCourse()
    {
        var course = _courseBuilder.Build();

        var id = _repository.Create(course);

        id.Should().BeGreaterThanOrEqualTo(0);
    }

    [Fact]
    public void Should_GetCourseByName()
    {
        var expected = "tdd-onion";
        var expectedCourse = _courseBuilder.WithName(expected).Build();
        _repository.Create(expectedCourse);

        var actual = _repository.GetBy(expected);

        actual.Name.Should().Be(expectedCourse.Name);
        actual.Tuition.Should().Be(expectedCourse.Tuition);
        actual.Instructor.Should().Be(expectedCourse.Instructor);
    }

    [Fact]
    public void Should_GetCourseById()
    {
        var expectedCourse = _courseBuilder.Build();
        var id = _repository.Create(expectedCourse);

        var actual = _repository.GetBy(id);

        actual.Should().Be(expectedCourse);
    }

    [Fact]
    public void Should_DeleteExistingCourse()
    {
        var course = _courseBuilder.Build();
        var id = _repository.Create(course);

        _repository.Delete(course.Id);

        var actual = _repository.GetBy(id);
        actual.Should().BeNull();
    }
}
