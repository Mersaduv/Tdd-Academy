namespace Academy.Application.Contract.Dtos;

public class EditCourseDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Tuition { get; set; }
    public string Instructor { get; set; }
    public bool IsOnline { get; set; }
}