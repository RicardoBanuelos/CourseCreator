using CourseCreator.Data;
using CourseCreator.Interfaces;
using CourseCreator.Models;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace CourseCreator.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDbContext _context;
        public CourseRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(Course course)
        {
            _context.Add(course);
            return Save();
        }

        public async Task<IEnumerable<Course>> GetAll()
        {
            return await _context.Courses.ToListAsync();
        }

        public async Task<Course> GetById(int id)
        {
            return await _context.Courses.FirstOrDefaultAsync(course => course.Id == id);
        }

        public bool Save()
        {
            int saved = _context.SaveChanges();
            return saved > 0;
        }
    }
}
