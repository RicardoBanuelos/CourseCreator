using CourseCreator.Models;

namespace CourseCreator.Interfaces
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetAll();
        Task<Course> GetById(int id);
        bool Add(Course course);
        bool Save();
    }
}
