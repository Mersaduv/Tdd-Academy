using Academy.Domain.Exceptions;
using Academy.Domain.Unit.Tests.Builder;
using Academy.Domain.Unit.Tests.ClassFixtures;
using Academy.Domain.Unit.Tests.CollectionFixtures;
using Academy.Domain.Unit.Tests.Factories;
using FluentAssertions;

namespace Academy.Domain.Tests;

[Collection("Database Collection")] // ICollectionFixture
public class CourseTests : IClassFixture<IdentifierFixture>// IClassFixture 
{
    private readonly CourseTestBuilder _courseBuilder;
    private readonly DatabaseFixture _databaseFixture;

    // constructor
    public CourseTests(DatabaseFixture databaseFixture) =>
    (_databaseFixture, _courseBuilder) = (databaseFixture, new CourseTestBuilder());

    [Fact]
    public void Constructor_ShouldConstructCourseProperly()
    {

        //  var guid = IdentifierFixture.Id; // IClassFixture 
        const string name = "tdd & bdd";
        const bool isOnline = true;
        const double tuition = 600;
        const string instructor = "mrsd";

        var course = _courseBuilder.Build();


        //assert
        course.Name.Should().Be(name);
        course.IsOnline.Should().Be(isOnline);
        course.Tuition.Should().Be(tuition);
        course.Instructor.Should().Be(instructor);
        course.Sections.Should().BeEmpty();
    }

    [Fact]
    public void AddSection_ShouldAddNewSectionToSections_WhenIdAndNamePassed()
    {
        var course = _courseBuilder.Build();
        var addSection = SectionFactory.Create();
        //act
        course.AddSection(addSection);
        //assert
        course.Sections.Should().ContainEquivalentOf(addSection);
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

    [Fact]
    public void Should_BeEqual_WhenIdIsEqual()
    {
        //arrange
        const int sameId = 1;
        var courseBuilder = new CourseTestBuilder();
        var course1 = courseBuilder.Build();
        course1.Id = sameId;
        var course2 = courseBuilder.Build();
        course2.Id = sameId;

        //act
        var actual = course1.Equals(course2);

        //assert
        actual.Should().BeTrue();
        //course1.Should().Be(course2);
    }

    [Fact]
    public void Should_NotBeEqual_WhenIdIsNotEqual()
    {
        //arrange
        var courseBuilder = new CourseTestBuilder();
        var course1 = courseBuilder.Build();
        course1.Id = 1;
        var course2 = courseBuilder.Build();
        course2.Id = 2;

        //act
        var actual = course1.Equals(course2);

        //assert
        actual.Should().BeFalse();
    }

    [Fact]
    public void Should_NotBeEqual_WhenIsNull()
    {
        //arrange
        var courseBuilder = new CourseTestBuilder();
        var course1 = courseBuilder.Build();

        //act
        var actual = course1.Equals(null);

        //assert
        actual.Should().BeFalse();
    }
}
