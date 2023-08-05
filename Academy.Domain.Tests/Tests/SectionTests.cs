using FluentAssertions;

namespace Academy.Domain.Tests.Tests;

public class SectionTests
{
    [Fact]
    public void Constructor_Shuold_Construct_Section_Properly()
    {
        const string name = "Tdd";
        const int id = 1;

        var course = new Section(id, name);

        course.Name.Should().Be(name);
        course.Id.Should().Be(id);
    }
}