using Academy.Application.Contract.Dtos;
using Academy.Domain;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using RESTFulSense.Clients;

namespace Academy.Presentation.Tests.Integration;

public class CourseControllerTests
{
    private const string path = "/api/course";

    private readonly RESTFulApiFactoryClient _restClient;
    public CourseControllerTests()
    {
        var applicationFactory = new WebApplicationFactory<Program>();
        var httpClient = applicationFactory.CreateClient();
        _restClient = new RESTFulApiFactoryClient(httpClient);
    }
    [Fact]
    public async Task Should_GetAllCourseAsync()
    {

        var actual = await _restClient.GetContentAsync<List<Course>>(path);

        actual.Should().HaveCountGreaterThanOrEqualTo(0);
    }

    [Fact]
    public async void Should_CreateNewCourse()
    {
        var command = SomeCreateCourse();

        var id = await _restClient.PostContentAsync<CreateCourseDto, int>(path, command);
        var courses = await _restClient.GetContentAsync<List<Course>>(path);

        courses.Should().ContainSingle(x => x.Id == id);
        await _restClient.DeleteContentAsync($"{path}/{id}");
    }

    private static CreateCourseDto SomeCreateCourse()
    {
        return new CreateCourseDto
        {
            Name = Guid.NewGuid().ToString(),//Only on the tests, the identification of duplicate nouns was prevented
            Instructor = "Mrsd",
            IsOnline = true,
            Tuition = 700,
        };
    }

    [Fact]
    public async void Should_EditExistingCourse()
    {
        var command = SomeCreateCourse();
        var id = await _restClient.PostContentAsync<CreateCourseDto, int>(path, command);
        var editCourse = new EditCourseDto
        {
            Id = id,
            Name = "ASP.NET Core 8",
            IsOnline = command.IsOnline,
            Tuition = 900,
        };

        var newId = await _restClient.PutContentAsync<object>(path, editCourse);

        var courses = await _restClient.GetContentAsync<List<Course>>(path);
        courses.Should().ContainSingle(x => x.Id == Convert.ToInt32(newId));
        courses.Should().NotContain(x => x.Id == id);

        await _restClient.DeleteContentAsync($"{path}/{newId}");

    }

    [Fact]
    public async void Should_DeleteCourse()
    {
        var command = SomeCreateCourse();
        var id = await _restClient.PostContentAsync<CreateCourseDto, int>(path, command);

        await _restClient.DeleteContentAsync($"{path}/{id}");

        var courses = await _restClient.GetContentAsync<List<Course>>(path);
        courses.Should().NotContain(x => x.Id == id);
    }
}