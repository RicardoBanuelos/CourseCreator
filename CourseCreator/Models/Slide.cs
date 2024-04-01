using System.ComponentModel.DataAnnotations;

namespace CourseCreator.Models
{
    public class Slide
    {
        [Key]
        public int Id { get; set; }
        public String Title { get; set; }
        public String Body { get; set; }
    }
}
