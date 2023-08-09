namespace Academy.Domain.Interfaces;

public interface ICourseRepository
{
    void Create(Course course);
    List<Course> GetAll();
    Course GetBy(int id);
    Course GetBy(string name);
    bool Delete(int id);
}