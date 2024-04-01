using CourseCreator.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseCreator.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<Slide> Slides { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
