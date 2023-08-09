using Academy.Domain.Exceptions;

namespace Academy.Domain;

public class Course
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsOnline { get; set; }
    public double Tuition { get; set; }
    public string Instructor { get; set; }
    public List<Section> Sections { get; set; }

    public Course(int id, string name, bool isOnline, double tuition, string instructor)
    {
        GuardAgainstInvalidName(name);

        GuardAgainstInvalidTuition(tuition);
        Id = id;
        Name = name;
        IsOnline = isOnline;
        Tuition = tuition;
        Instructor = instructor;
        Sections = new List<Section>();
    }

    private static void GuardAgainstInvalidTuition(double tuition)
    {
        if (tuition <= 0)
        {
            throw new CourseTuitionIsInvalidExecution();
        }
    }

    private static void GuardAgainstInvalidName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new CourseNameIsInvalidException();
    }

    public void AddSection(Section addSection)
    {
        Sections.Add(addSection);
    }

    // override object.Equals
    public override bool Equals(object obj)
    {
        if (!(obj is Course course))
            return false;

        return Id == course.Id;
    }


}