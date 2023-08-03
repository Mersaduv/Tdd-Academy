namespace Academy.Domain.Tests.Builder;

public class CourseTestBuilder
{
    private const int Id = 1;
    private string _name = "tdd & bdd";
    private const bool IsOnline = true;
    private double _tuition = 600;
    private const string Instructor = "hossein";
    public Course Build()
    {
        return new Course(Id, _name, IsOnline, _tuition, Instructor);
    }

    public CourseTestBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public CourseTestBuilder WithTuition(double tuition)
    {
        _tuition = tuition;
        return this;
    }
}
