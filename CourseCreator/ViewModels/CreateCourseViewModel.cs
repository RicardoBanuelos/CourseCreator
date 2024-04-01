using CourseCreator.Models;

namespace CourseCreator.ViewModels
{
	public class CreateCourseViewModel
	{
		public IEnumerable<Slide>? Slides { get; set; }
		public string Title { get; set; }		
		public string Thumbnail { get; set; }
		public string SlidesIds { get; set; }
		public bool InvalidSlides { get; set; }
	}
}
