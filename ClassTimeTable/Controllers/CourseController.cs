using ClassTimeTable.Models.Domain;
using ClassTimeTable.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace ClassTimeTable.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IInstructorRepository _instructorRepository;
        private readonly IBatchRepository _batchRepository;

        public CourseController(ICourseRepository courseRepository,
                                IInstructorRepository instructorRepository,
                                IBatchRepository batchRepository)
        {
            _courseRepository = courseRepository;
            _instructorRepository = instructorRepository;
            _batchRepository = batchRepository;
        }

        public IActionResult Index()
        {
            return View(_courseRepository.GetCourses());
        }

        public IActionResult Create()
        {
            var instructor = _instructorRepository.GetInstructors();
            ViewData["iId"] = new SelectList(instructor, "Id", "Name");

            var batch = _batchRepository.GetBatches();
            ViewData["bId"] = new SelectList(batch, "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Course course)
        {

            if (ModelState.IsValid)
            {
                _courseRepository.Create(course);
                return RedirectToAction(nameof(Index));
            }

            return View(course);
        }

        public IActionResult Update(int id)
        {
            var instructor = _instructorRepository.GetInstructors();
            ViewData["iId"] = new SelectList(instructor, "Id", "Name");

            var batch = _batchRepository.GetBatches();
            ViewData["bId"] = new SelectList(batch, "Id", "Name");

            var course = _courseRepository.GetCourse(id);

            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Course course)
        {
            if (ModelState.IsValid)
            {
                _courseRepository.Update(course);
                return RedirectToAction(nameof(Index));
            }

            return View(course);
        }

        public IActionResult Delete(int id)
        {
            var course = _courseRepository.GetCourse(id);

            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(Course course)
        {
            if (ModelState.IsValid)
            {
                _courseRepository.Delete(course);
                return RedirectToAction(nameof(Index));
            }

            return View(course);
        }
    }
}
