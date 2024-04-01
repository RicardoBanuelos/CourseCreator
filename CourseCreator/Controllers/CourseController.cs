using CourseCreator.Interfaces;
using CourseCreator.Models;
using CourseCreator.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CourseCreator.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseRepository _courseRepository;
        private readonly ISlideRepository _slideRepository;
        public CourseController(ICourseRepository courseRepository, ISlideRepository slideRepository)
        {
            _courseRepository = courseRepository;
            _slideRepository = slideRepository;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Course> courses = await _courseRepository.GetAll();
            return View(courses);
        }

        public async Task<IActionResult> Create() 
        {
            CreateCourseViewModel createCourseVM = new CreateCourseViewModel
            {
                Slides = await _slideRepository.GetAll(),
                InvalidSlides = false
            };

            return View(createCourseVM);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCourseViewModel createCourseVM)
        {
            if (ModelState.IsValid)
            {
                bool InvalidSlides = false;
                List<int> SlidesIds = new List<int>();

                try
                {
					SlidesIds = createCourseVM.SlidesIds.Split(',').Select(int.Parse).ToList();
				}
                catch (Exception e) 
                { 
                    InvalidSlides = true;
                }

                if(SlidesIds.Count == 0)
                {
                    InvalidSlides = true;
				}

                foreach(int id in SlidesIds)
                {
                    bool hasSlide = await _slideRepository.HasSlide(id);
					if (!hasSlide)
                    {
                        InvalidSlides = true;
                        break;
					}
                }

                if(InvalidSlides)
                {
                    createCourseVM.Slides = await _slideRepository.GetAll();
                    createCourseVM.InvalidSlides = true;
					return View(createCourseVM);
				}

				Course course = new Course()
                {
                    Title = createCourseVM.Title,
                    Thumbnail = createCourseVM.Thumbnail,
                    SlidesIds = createCourseVM.SlidesIds
                };

                _courseRepository.Add(course);
				return RedirectToAction("Index");
			}

			createCourseVM.Slides = await _slideRepository.GetAll();
			return View(createCourseVM);
		}

        public async Task<IActionResult> Content(int id)
        {
            Course course = await _courseRepository.GetById(id);

            List<Slide> slides = new List<Slide>();
            List<int> slideIds = course.SlidesIds.Split(',').Select(int.Parse).ToList();


            foreach (int slideId in slideIds)
            {
                slides.Add(await _slideRepository.GetById(slideId));
            }

            CourseContentViewModel courseContentVM = new CourseContentViewModel()
            {
                Title = course.Title,
                Slides = slides,
            };

            return View(courseContentVM);
        }
    }
}
