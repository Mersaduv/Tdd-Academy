using System.Transactions;
using Academy.Domain;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace Academy.Infrastructure.Tests.Integration;

public class CourseRepositoryTests : IClassFixture<RealDatabaseFixture>
{
    private readonly CourseRepository repository;
    public CourseRepositoryTests(RealDatabaseFixture databaseFixture)
    {
        repository = new CourseRepository(databaseFixture.Context);
    }


    [Fact]
    public void Should_ReturnAllCourses()
    {

        var course = repository.GetAll();

        course.Should().HaveCountGreaterThanOrEqualTo(0);
    }

    [Fact]
    public void Should_CreateCourse()
    {
        var course = new Course(0, "tdd22", true, 12243, "2mersad");

        repository.Create(course);

        var courses = repository.GetAll();
        courses.Should().Contain(course);
    }
}
