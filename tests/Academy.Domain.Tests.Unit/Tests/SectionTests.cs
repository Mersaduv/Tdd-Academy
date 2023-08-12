using Academy.Domain.Unit.Tests.CollectionFixtures;

using FluentAssertions;

namespace Academy.Domain.Tests.Tests;

[Collection("Database Collection")]// ICollectionFixture
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