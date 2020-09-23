using ClassTimeTable.Models.Domain;
using ClassTimeTable.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace ClassTimeTable.Controllers
{
    public class ClassController : Controller
    {
        private readonly IClassRepository _classRepository;
        private readonly IBatchRepository _batchRepository;
        private readonly IInstructorRepository _instructorRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IMeetingTimeRepository _meetingTimeRepository;
        private readonly IRoomRepository _roomRepository;

        public ClassController(IClassRepository classRepository,
                               IBatchRepository batchRepository,
                               IInstructorRepository instructorRepository,
                               ICourseRepository courseRepository,
                               IMeetingTimeRepository meetingTimeRepository,
                               IRoomRepository roomRepository

                                )
        {
            _classRepository = classRepository;
            _batchRepository = batchRepository;
            _instructorRepository = instructorRepository;
            _courseRepository = courseRepository;
            _meetingTimeRepository = meetingTimeRepository;
            _roomRepository = roomRepository;
        }

        public IActionResult Index()
        {
            return View(_classRepository.GetClasses());
        }

        public IActionResult Create()
        {
            var batches = _batchRepository.GetBatches();
            ViewData["bId"] = new SelectList(batches, "Id", "Name");


            var course = _courseRepository.GetCourses();
            ViewData["cId"] = new SelectList(course, "Id", "CourseTitle");


            var meetingTime = _meetingTimeRepository.GetMeetingTimes();
            ViewData["mId"] = new SelectList(meetingTime, "Id", "Time");


            var room = _roomRepository.GetRooms();
            ViewData["rId"] = new SelectList(room, "Id", "Name");


            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(Class cls)
        {
            if (ModelState.IsValid)
            {
                _classRepository.Create();
                return RedirectToAction(nameof(Index));
            }

            return View(cls);
        }

        public IActionResult Update(int id)
        {

            var batches = _batchRepository.GetBatches();
            ViewData["bId"] = new SelectList(batches, "Id", "Name");


            var course = _courseRepository.GetCourses();
            ViewData["cId"] = new SelectList(course, "Id", "CourseTitle");


            var meetingTime = _meetingTimeRepository.GetMeetingTimes();
            ViewData["mId"] = new SelectList(meetingTime, "Id", "Time");


            var room = _roomRepository.GetRooms();
            ViewData["rId"] = new SelectList(room, "Id", "Name");

            var cls = _classRepository.GetClass(id);

            if (cls == null)
            {
                return NotFound();
            }


            return View(cls);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Class cls)
        {
            if (ModelState.IsValid)
            {
                _classRepository.Update(cls);
                return RedirectToAction(nameof(Index));
            }

            return View(cls);
        }

        public IActionResult Delete(int id)
        {
            var cls = _classRepository.GetClass(id);

            if (cls == null)
            {
                return NotFound();
            }

            return View(cls);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Class cls)
        {
            if (ModelState.IsValid)
            {
                _classRepository.Delete(cls);
                return RedirectToAction(nameof(Index));
            }

            return View(cls);
        }



    }
}
