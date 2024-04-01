using CourseCreator.Interfaces;
using CourseCreator.Models;
using Microsoft.AspNetCore.Mvc;

namespace CourseCreator.Controllers
{
    public class SlideController : Controller
    {
        private readonly ISlideRepository _slideRepository;
        public SlideController(ISlideRepository slideRepository)
        {
            _slideRepository = slideRepository;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Slide> slides = await _slideRepository.GetAll();
            return View(slides);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Slide slide)
        {
            if(!ModelState.IsValid) 
            {
                return View(slide);
            }

            _slideRepository.Add(slide);
            return RedirectToAction("Index");
        }
    }
}
