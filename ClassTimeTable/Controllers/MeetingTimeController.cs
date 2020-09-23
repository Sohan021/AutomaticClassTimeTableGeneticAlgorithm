using ClassTimeTable.Models.Domain;
using ClassTimeTable.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ClassTimeTable.Controllers
{
    public class MeetingTimeController : Controller
    {
        private readonly IMeetingTimeRepository _meetingTimeRepository;

        public MeetingTimeController(IMeetingTimeRepository meetingTimeRepository)
        {
            _meetingTimeRepository = meetingTimeRepository;
        }

        public IActionResult Index()
        {
            return View(_meetingTimeRepository.GetMeetingTimes());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(MeetingTime meetingTime)
        {
            if (ModelState.IsValid)
            {
                _meetingTimeRepository.Create(meetingTime);
                return RedirectToAction(nameof(Index));
            }

            return View(meetingTime);
        }

        public IActionResult Update(int id)
        {
            var meetingTime = _meetingTimeRepository.GetMeetingTime(id);

            if (meetingTime == null)
            {
                return NotFound();
            }

            return View(meetingTime);
        }

        [HttpPost]
        public async Task<IActionResult> Update(MeetingTime meetingTime)
        {
            if (ModelState.IsValid)
            {
                _meetingTimeRepository.Update(meetingTime);
                return RedirectToAction(nameof(Index));
            }

            return View(meetingTime);
        }



        public IActionResult Delete(int id)
        {
            var meetingTime = _meetingTimeRepository.GetMeetingTime(id);

            if (meetingTime == null)
            {
                return NotFound();
            }

            return View(meetingTime);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(MeetingTime meetingTime)
        {
            if (ModelState.IsValid)
            {
                _meetingTimeRepository.Delete(meetingTime);
                return RedirectToAction(nameof(Index));
            }

            return View(meetingTime);
        }
    }
}
