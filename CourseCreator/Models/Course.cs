using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseCreator.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        public String Title { get; set; }
        public String? Thumbnail { get; set; }
        public String SlidesIds { get; set; }
    }
}
