using ClassTimeTable.Models.Domain;
using ClassTimeTable.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ClassTimeTable.Controllers
{
    public class InstructorController : Controller
    {
        private IInstructorRepository _instructorRepository;

        public InstructorController(IInstructorRepository instructorRepository)
        {
            _instructorRepository = instructorRepository;
        }

        public IActionResult Index()
        {
            return View(_instructorRepository.GetInstructors());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                _instructorRepository.Create(instructor);
                return RedirectToAction(nameof(Index));
            }
            return View(instructor);
        }

        public IActionResult Update(int id)
        {
            var instructor = _instructorRepository.GetInstructor(id);

            if (instructor == null)
            {
                return NotFound();
            }

            return View(instructor);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                _instructorRepository.Update(instructor);
                return RedirectToAction(nameof(Index));
            }

            return View(instructor);
        }


        public IActionResult Delete(int id)
        {
            var ins = _instructorRepository.GetInstructor(id);

            if (ins == null)
            {
                return NotFound();
            }

            return View(ins);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                _instructorRepository.Delete(instructor);
                return RedirectToAction(nameof(Index));
            }

            return View(instructor);
        }
    }
}
