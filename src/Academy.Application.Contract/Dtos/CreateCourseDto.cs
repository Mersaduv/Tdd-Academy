using Academy.Domain;

namespace Academy.Application.Contract.Dtos;
public class CreateCourseDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsOnline { get; set; }
    public double Tuition { get; set; }
    public string Instructor { get; set; }
    public List<Section> Sections { get; set; }

}