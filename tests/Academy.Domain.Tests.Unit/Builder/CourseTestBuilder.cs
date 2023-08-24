namespace Academy.Domain.Unit.Tests.Builder;

public class CourseTestBuilder
{
    private string _name = "tdd & bdd";
    private const bool IsOnline = true;
    private double _tuition = 600;
    private string Instructor = "mrsd";
    public Course Build()
    {
        return new Course(_name, IsOnline, _tuition, Instructor);
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

    public CourseTestBuilder WithInstructor(string instructor)
    {
        Instructor = instructor;
        return this;
    }
}
