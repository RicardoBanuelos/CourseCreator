using CourseCreator.Data;
using CourseCreator.Interfaces;
using CourseCreator.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseCreator.Repositories
{
    public class SlideRepository : ISlideRepository
    {
        private readonly ApplicationDbContext _context;
        public SlideRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(Slide slide)
        {
            _context.Add(slide);
            return Save();
        }

        public async Task<IEnumerable<Slide>> GetAll()
        {
            return await _context.Slides.ToListAsync();
        }

        public async Task<Slide> GetById(int id)
        {
            return await _context.Slides.FirstOrDefaultAsync(slide => slide.Id == id);
        }

		public async Task<bool> HasSlide(int id)
        {
            return await _context.Slides.AnyAsync(slide => slide.Id == id);
        }

		public bool Save()
        {
            int saved = _context.SaveChanges();
            return saved > 0;
        }
	}
}
