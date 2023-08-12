// using Academy.Domain.Unit.Tests.Builder;
// using FluentAssertions;

//? Unit Testing
// namespace Academy.Infrastructure.Unit.Tests;

// public class CourseRepositoryTests
// {
//     private readonly CourseRepository _courseRepository;
//     private readonly CourseTestBuilder _courseBuilder;
//     public CourseRepositoryTests() =>
//      (_courseRepository, _courseBuilder) = (new CourseRepository(), new CourseTestBuilder());


//     [Fact]
//     public void Should_AddNewCourseToCourseList()
//     {
//         var course = _courseBuilder.Build();

//         _courseRepository.Create(course);

//         _courseRepository.Courses.Should().Contain(course);
//         _courseRepository.Courses.Should().ContainEquivalentOf(course);
//     }

//     [Fact]
//     public void Should_ReturnListOfCourses()
//     {
//         var courses = _courseRepository.GetAll();

//         courses.Should().HaveCountGreaterThan(0);
//     }

//     [Fact]
//     public void Should_ReturnCourseById()
//     {
//         const int id = 111;
//         var expected = _courseBuilder.WithId(id).Build();
//         _courseRepository.Create(expected);

//         var actual = _courseRepository.GetBy(id);

//         actual.Should().Be(expected);
//     }

//     [Fact]
//     public void Should_ReturnNull_WhenIdNotExists()
//     {
//         const int id = 53;

//         var actual = _courseRepository.GetBy(id);

//         actual.Should().BeNull();
//     }

//     [Fact]
//     public void Should_DeleteCourseFromStore()
//     {
//         const int id = 666;
//         var course = _courseBuilder.WithId(id).Build();
//         _courseRepository.Create(course);

//         _courseRepository.Delete(id);


//         _courseRepository.Courses.Should().NotContain(course);

//     }


//         [Fact]
//         public void Should_ReturnNull_WhenCourseWithNameNotExists()
//         {
//             const string webDesign = "web Design";

//             var actual = _courseRepository.GetBy(webDesign);

//             actual.Should().BeNull();
//         }

// }
