using CourseCreator.Models;

namespace CourseCreator.Interfaces
{
    public interface ISlideRepository
    {
        Task<IEnumerable<Slide>> GetAll();
        Task<Slide> GetById(int id);
        Task<bool> HasSlide(int id);
        bool Add(Slide slide);
        bool Save();
    }
}
