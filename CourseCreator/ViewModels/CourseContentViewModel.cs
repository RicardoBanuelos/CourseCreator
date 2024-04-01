using CourseCreator.Models;

namespace CourseCreator.ViewModels
{
    public class CourseContentViewModel
    {
        public string Title { get; set; }
        public List<Slide> Slides { get; set; }
    }
}
